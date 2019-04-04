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
            Title = "Detailed Bar Page";
            _navigationService = navigationService;
            RestClient = new StubRestClient();
            Bar = new Bar();
            OnLoadItemsCommand();
        }

        public Bar Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }


        public void OnLoadItemsCommand()
        {
            var barDto = RestClient.GetDetailedBar("Katrine").Result;
            Bar.Rating = barDto.AvgRating;
            Bar.AboutText = barDto.ShortDescription;
            Bar.LongAboutText = barDto.LongDescription;
            Bar.Address = barDto.Address;
            Bar.Image = "katrine.png";
            Bar.AgeRestriction = barDto.AgeLimit;

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