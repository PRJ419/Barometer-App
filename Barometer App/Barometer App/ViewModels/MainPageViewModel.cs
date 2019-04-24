using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Barometer_App.Models;

namespace Barometer_App.ViewModels
{
    /// <summary>
    /// ViewModel for the MainMenu View, also being the hub for all navigation it has a lot of navigation commands
    /// It also defines some of the initializing for the variables used by the rest of the app
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {

        public ObservableCollection<Bar> Bars { get; set; }

        /// <summary>
        /// Private version of the bindable property for the ViewModel to hold
        /// </summary>
        private Customer _customer;

        /// <summary>
        /// Public bindable Customer class for the View to bind to and access login status from
        /// </summary>
        public Customer customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        /// <summary>
        /// Navigation Service provided by Prism
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Constructor for the ViewModel for the MainMenu View
        /// It sets the Title and loads the Customer into the application
        /// </summary>
        /// <param name="navigationService">
        /// A reference to the navigationService object provided by Prism
        /// </param>
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Bar-O-Meter";

            //Load this in later
            customer = Customer.getCustomer();
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _logoutCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand LogoutCommand => _logoutCommand ?? (_logoutCommand = new DelegateCommand(OnLogout));

        /// <summary>
        /// Logic that defines behaviour for the Logout command
        /// </summary>
        public void OnLogout()
        {
            customer.UserToken = null;
        }

        #region NavCommands

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _navShowBarsCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand NavShowBarsCommand => _navShowBarsCommand ?? (_navShowBarsCommand = new DelegateCommand(OnNavShowBars));

        /// <summary>
        /// Logic that defines behaviour for the navigation to Bar List 
        /// </summary>
        public async void OnNavShowBars()
        {
            var navParams = new NavigationParameters();
            navParams.Add("Bars", Bars);

            await _navigationService.NavigateAsync("BarList", navParams);
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _navLoginCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand NavLoginCommand => _navLoginCommand ?? (_navLoginCommand = new DelegateCommand(OnNavLogin));

        /// <summary>
        /// Logic that defines behaviour for the navigation to Login 
        /// </summary>
        public async void OnNavLogin()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("Login", navParams);
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _navSignupCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand NavSignupCommand => _navSignupCommand ?? (_navSignupCommand = new DelegateCommand(OnNavSignUp));

        /// <summary>
        /// Logic that defines behaviour for the navigation to Signup
        /// </summary>
        public async void OnNavSignUp()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("Signup", navParams);
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _navAboutCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand NavAboutCommand => _navAboutCommand ?? (_navAboutCommand = new DelegateCommand(OnNavAbout));

        /// <summary>
        /// Logic that defines behaviour for the navigation to About 
        /// </summary>
        public async void OnNavAbout()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("DetailedBarEdit", navParams);
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _navSettingsCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand NavSettingsCommand => _navSettingsCommand ?? (_navSettingsCommand = new DelegateCommand(OnNavSettings));

        /// <summary>
        /// Logic that defines behaviour for the navigation to Settings
        /// </summary>
        public async void OnNavSettings()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("Settings", navParams);
        }
        #endregion
    }
}
