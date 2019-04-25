using System.Windows.Input;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    public class BarRatingViewModel : ViewModelBase
    {
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

        private Review _review;

        private readonly INavigationService _navigationService;
        public BarRatingViewModel(INavigationService navigationService)
        {
            _bar = new Bar();
            _navigationService = navigationService;
            _review = new Review();
            Customer = Customer.GetCustomer();

            //stub
            Customer.UserName = "k00ziex";
        }

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

        private int _barRating;
        public int BarRating
        {
            get => _barRating;
            set => SetProperty(ref _barRating, value);
        }

        private ICommand _rateCommand;

        public ICommand RateCommand => _rateCommand ?? (_rateCommand = new DelegateCommand(OnRateCommand));

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