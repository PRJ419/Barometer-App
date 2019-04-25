using System.Windows.Input;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    /// <summary>
    /// ViewModel for the detailed bar View
    /// </summary>
    public class DetailedBarViewModel : ViewModelBase
    {
        /// <summary>
        /// Property to hold the currently accessed bar
        /// </summary>
        private Bar _bar;

        /// <summary>
        /// Bindable Bar property for the View to access
        /// </summary>
        public Bar Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }

        /// <summary>
        /// Constructor for the ViewModel of the detailed bar View
        /// </summary>
        /// <param name="navigationService">
        /// Navigation service provided by Prism
        /// </param>
        public DetailedBarViewModel(INavigationService navigationService) : base()
        {
            NavigationService = navigationService;
            Bar = new Bar();
        }

        /// <inheritdoc />
        /// <summary>
        /// Override of the OnNavigatedTo method from INavigationAware
        /// Gets the barName from the parameter and calls the load method
        /// </summary>
        /// <param name="parameters">
        /// Parameter list which is used to hold the barName
        /// </param>
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var barName = parameters.GetValue<string>("Bar");
            if (barName == null) return;
            OnLoadItemsCommand(barName);
        }

        /// <summary>
        /// Used to load in the details of a specific bar
        /// It uses the RestClient to do so
        /// It also divides AvgRating in 5 so it fits progressbar widget
        /// </summary>
        /// <param name="bar">
        /// Name of the bar that needs loading
        /// </param>
        public async void OnLoadItemsCommand(string bar)
        {
            Bar = await RestClient.GetDetailedBar(bar);
            Bar.AvgRating = Bar.AvgRating / 5;
            Title = Bar.BarName;
        }

        #region Commands       
        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _ratingCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand RatingCommand => _ratingCommand ?? (_ratingCommand = new DelegateCommand(OnRatingCommand, CanRateCommand));

        /// <summary>
        /// Logic that defines behaviour for the navigation to the BarRating view
        /// </summary>
        private async void OnRatingCommand()
        {
            var navigationParameters = new NavigationParameters {{"Bar", Bar.BarName}};
            await NavigationService.NavigateAsync("BarRating", navigationParameters);
        }

        private static bool CanRateCommand()
        {
            return User.GetCustomer().LoggedIn;
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _drinksCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand DrinksCommand => _drinksCommand ?? (_drinksCommand = new DelegateCommand(OnDrinksCommand));

        /// <summary>
        /// Logic that defines behaviour for the navigation to the DrinkList view 
        /// </summary>
        private async void OnDrinksCommand()
        {
            var navParams = new NavigationParameters {{"Bar", Bar.BarName}};
            await NavigationService.NavigateAsync("DrinkList", navParams);
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _eventCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand EventCommand => _eventCommand ?? (_eventCommand = new DelegateCommand(OnEventCommand));

        /// <summary>
        /// Logic that defines behaviour for the navigation to the Events view
        /// </summary>
        private async void OnEventCommand()
        {
            var navParams = new NavigationParameters{{"Bar", Bar.BarName}};
            await NavigationService.NavigateAsync("Events", navParams);
        }
        #endregion
    }
}