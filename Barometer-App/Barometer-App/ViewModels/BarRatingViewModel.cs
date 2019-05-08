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
        public bool NewReview = false;
        /// <summary>
        /// Property for holding the currently accessed bar
        /// </summary>
        /// <summary>
        /// Private version of the bindable property for the ViewModel to hold
        /// </summary>
        private User _customer;
        public User Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }
        private Review _review;

        /// <summary>
        /// Constructor for the ViewModel of the BarRating View
        /// Constructs bar and sets the navigation service
        /// </summary>
        /// <param name="navigationService">
        /// Navigation service provided by Prism
        /// </param>
        public BarRatingViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            _review = new Review();
            Customer = User.GetCustomer();
        }

        /// <inheritdoc />
        /// <summary>
        /// Override of the OnNavigatedTo method from INavigationAware
        /// </summary>
        /// <param name="parameters">
        /// Parameter list which is used to hold the barname
        /// </param>
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            var bar = parameters.GetValue<string>("Bar");
            Title = "Rate " + bar;
            _review = await RestClient.GetSpecificBarReview(bar, Customer.UserName);
            //Update the database with a new review if none exists.
            //This could have been done in a model, but that takes a lot of
            //unnecessary data transfer
            if (_review.BarName == null)
            {
                NewReview = true;
                BarRating = 1;
            }
            else
                BarRating = _review.BarPressure;
            _review.BarName = bar;
            _review.Username = Customer.UserName;
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
            _review.BarPressure = BarRating;
            if(NewReview)
                await RestClient.CreateReview(_review);
            else
                await RestClient.EditReview(_review);

            var navParams = new NavigationParameters { { "Bar", _review.BarName } };
            await NavigationService.GoBackAsync(navParams);
        }
    }
}