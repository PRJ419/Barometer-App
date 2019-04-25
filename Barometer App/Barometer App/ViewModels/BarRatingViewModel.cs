using System.Windows.Input;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    /// <summary>
    /// ViewModel for the BarRating View
    /// </summary>
    public class BarRatingViewModel : ViewModelBase
    {
        /// <summary>
        /// Property for holding the currently accessed bar
        /// </summary>
        /// <summary>
        /// Private version of the bindable property for the ViewModel to hold
        /// </summary>
        private Customer _customer;
        public Customer Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        private Bar _bar;

        /// <summary>
        /// Navigation service for navigation of the views
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Constructor for the ViewModel of the BarRating View
        /// Constructs bar and sets the navigation service
        /// </summary>
        /// <param name="navigationService">
        /// Navigation service provided by Prism
        /// </param>
        public BarRatingViewModel(INavigationService navigationService)
        {
            _bar = new Bar();
            _navigationService = navigationService;
            _review = new Review();
            Customer = Customer.GetCustomer();

            //stub
            Customer.UserName = "k00ziex";
        }

        /// <summary>
        /// Override of the OnNavigatedTo method from INavigationAware
        /// TODO: Skulle måske ikke load'e baren igen når det forrige view har denne information
        /// </summary>
        /// <param name="parameters">
        /// Parameter list which is used to hold the barname
        /// </param>
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            var bar = parameters.GetValue<string>("Bar");
            _review = await RestClient.GetSpecificBarReview(bar, Customer.UserName);
            //Update the database with a new review if none exists. 
            if (_review.BarName == null) {
                _review.BarName = bar;
                _review.Username = Customer.UserName;
                _review.BarPressure = 5;
                await RestClient.CreateReview(_review);              
            }
            BarRating = _review.BarPressure;
        }

        /// <summary>
        /// Property for holding the rating of the bar
        /// </summary>
        private int _barRating;

        /// <summary>
        /// Bindable property for the View
        /// </summary>
        public int BarRating
        {
            get => _barRating;
            set => SetProperty(ref _barRating, value);
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _rateCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand RateCommand => _rateCommand ?? (_rateCommand = new DelegateCommand(OnRateCommand));

        /// <summary>
        /// Logic that defines behaviour for the rating of the bar
        /// </summary>
        private async void OnRateCommand()
        {
            //_bar.AvgRating = (double)BarRating/5;
            //await RestClient.EditBar(_bar);

            _review.BarPressure = BarRating;
            await RestClient.EditReview(_review);

            var navParams = new NavigationParameters { { "Bar", _review.BarName } };
            await _navigationService.GoBackAsync(navParams);
        }
    }
}