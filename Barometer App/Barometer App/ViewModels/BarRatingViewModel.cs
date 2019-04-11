using System.Windows.Input;
using Barometer_App.Models;
using Barometer_App.ViewModels;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    public class BarRatingViewModel : ViewModelBase
    {

        private Bar _bar;
        private readonly INavigationService _navigationService;
        private readonly IRestClient _restClient;
        public BarRatingViewModel(INavigationService navigationService) : base()
        {
            _bar = new Bar();
            _navigationService = navigationService;
            _restClient = new RestClient();

        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            var bar = parameters.GetValue<string>("Bar");
           _bar = await _restClient.GetDetailedBar(bar);
           BarRating = (int)(_bar.AvgRating*5);
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
            _bar.AvgRating = (double)BarRating/5;
            await _restClient.EditBar(_bar);
            var navParams = new NavigationParameters {{"Bar", _bar.BarName}};
            await _navigationService.GoBackAsync(navParams);
        }
    }
}