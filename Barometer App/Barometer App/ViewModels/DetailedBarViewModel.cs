using System.Windows.Input;
using Barometer_App.Models;
using Barometer_App.ViewModels;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;
using RESTClient.DTOs;

namespace Barometer_App.ViewModels
{
    public class DetailedBarViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public IRestClient RestClient { get; set; }

        public DetailedBarViewModel(INavigationService navigationService) : base()
        {
            Title = "Detailed Bar Page";
            _navigationService = navigationService;
            RestClient = new StubRestClient();
            Bar = new DetailedBarViewDTO();
            OnLoadItemsCommand();
        }



        private DetailedBarViewDTO _bar;
        public DetailedBarViewDTO Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }


        public void OnLoadItemsCommand()
        {
            var barDto = RestClient.GetDetailedBar("Katrine").Result;
            Bar.AvgRating = barDto.AvgRating / 5;
            Bar.LongDescription = barDto.LongDescription;
            Bar.Address = barDto.Address;
            Bar.Image = "katrine.png";
            Bar.AgeRestriction = barDto.AgeRestriction;

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