using System.Windows.Input;
using Barometer_App.Models;
using Barometer_App.ViewModels;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    public class DetailedBarViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public IRestClient RestClient { get; set; }

        private Bar _bar;
        public DetailedBarViewModel(INavigationService navigationService) : base()
        {
            _navigationService = navigationService;
            RestClient = new RestClient();
            Bar = new Bar();
            Title = Bar.BarName;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var barName = parameters.GetValue<string>("Bar");
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
            Bar.Image = "katrine.png";
        }

        private ICommand _ratingCommand;

        public ICommand RatingCommand => _ratingCommand ?? (_ratingCommand = new DelegateCommand(OnRatingCommand));

        public async void OnRatingCommand()
        {
            var navigationParameters = new NavigationParameters {{"Bar", Bar}};
            await _navigationService.NavigateAsync("BarRating", navigationParameters);
        }
    }
}