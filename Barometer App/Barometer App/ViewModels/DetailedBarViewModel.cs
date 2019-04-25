using System.Windows.Input;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    public class DetailedBarViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private Bar _bar;
        public DetailedBarViewModel(INavigationService navigationService) : base()
        {
            _navigationService = navigationService;
            Bar = new Bar();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var barName = parameters.GetValue<string>("Bar");
            if (barName == null) return;
            OnLoadItemsCommand(barName);
        }

        public Bar Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }

        public async void OnLoadItemsCommand(string bar)
        {
            Bar = await RestClient.GetDetailedBar(bar);
            Bar.AvgRating = Bar.AvgRating / 5;
            Title = Bar.BarName;
        }

        private ICommand _ratingCommand;

        public ICommand RatingCommand => _ratingCommand ?? (_ratingCommand = new DelegateCommand(OnRatingCommand));

        public async void OnRatingCommand()
        {
            var navigationParameters = new NavigationParameters {{"Bar", Bar.BarName}};
            await _navigationService.NavigateAsync("BarRating", navigationParameters);
        }

        private ICommand _drinksCommand;

        public ICommand DrinksCommand => _drinksCommand ?? (_drinksCommand = new DelegateCommand(OnDrinksCommand));

        private async void OnDrinksCommand()
        {
            var navParams = new NavigationParameters {{"Bar", Bar.BarName}};
            await _navigationService.NavigateAsync("DrinkList", navParams);
        }

        private ICommand _eventCommand;

        public ICommand EventCommand => _eventCommand ?? (_eventCommand = new DelegateCommand(OnEventCommand));

        private async void OnEventCommand()
        {
            var navParams = new NavigationParameters{{"Bar", Bar.BarName}};
            await _navigationService.NavigateAsync("Events", navParams);
        }
    }
}