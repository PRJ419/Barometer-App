using System.Windows.Input;
using Barometer_App.Models;
using Barometer_App.ViewModels;
using Prism.Commands;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    public class DetailedBarViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private Bar _bar;
        public DetailedBarViewModel(INavigationService navigationService) : base()
        {
            Title = "Detailed Bar Page";
            _navigationService = navigationService;
            _bar = new Bar();
        }

        public Bar Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            var bar = parameters.GetValue<Bar>("Bar");
            Bar = bar;
        }

        private ICommand _ratingCommand;

        public ICommand RatingCommand => _ratingCommand ?? (_ratingCommand = new DelegateCommand(OnRatingCommand));

        public async void OnRatingCommand()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("Bar", Bar);
            await _navigationService.NavigateAsync("BarRating", navigationParameters);
        }
    }
}