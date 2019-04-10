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

        private Bar _tempbar;

        private Bar _bar;
        public DetailedBarViewModel(INavigationService navigationService) : base()
        {
            _navigationService = navigationService;
            RestClient = new RestClient();
            Bar = new Bar();
            _tempbar = new Bar();
            OnLoadItemsCommand(_tempbar.Name);
            Title = Bar.Name;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _tempbar = parameters.GetValue<Bar>("Bar");
        }

        public Bar Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }


        public async void OnLoadItemsCommand(string bar)
        {
            var barDto = await RestClient.GetDetailedBar(bar);
            Bar.Rating = barDto.AvgRating/5;
            Bar.AboutText = barDto.ShortDescription;
            Bar.LongAboutText = barDto.LongDescription;
            Bar.Address = barDto.Address;
            Bar.Image = "katrine.png";
            Bar.AgeRestriction = barDto.AgeLimit;
            Bar.Name = barDto.BarName;
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