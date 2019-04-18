using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Barometer_App.Models;

namespace Barometer_App.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Bar> Bars { get; set; }

        private Customer _customer;
        public Customer customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        private readonly INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Bar-O-Meter";

            //Load this in later
            customer = Customer.getCustomer();
        }

        private ICommand _logoutCommand;

        public ICommand LogoutCommand => _logoutCommand ?? (_logoutCommand = new DelegateCommand(OnLogout));

        public void OnLogout()
        {
            customer.UserToken = null;
        }

        #region NavCommands

        private ICommand _navShowBarsCommand;

        public ICommand NavShowBarsCommand => _navShowBarsCommand ?? (_navShowBarsCommand = new DelegateCommand(OnNavShowBars));

        public async void OnNavShowBars()
        {
            var navParams = new NavigationParameters();
            navParams.Add("Bars", Bars);

            await _navigationService.NavigateAsync("BarList", navParams);
        }

        private ICommand _navLoginCommand;

        public ICommand NavLoginCommand => _navLoginCommand ?? (_navLoginCommand = new DelegateCommand(OnNavLogin));


        public async void OnNavLogin()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("Login", navParams);
        }

        private ICommand _navSignupCommand;

        public ICommand NavSignupCommand => _navSignupCommand ?? (_navSignupCommand = new DelegateCommand(OnNavSignUp));

        public async void OnNavSignUp()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("Signup", navParams);
        }

        private ICommand _navAboutCommand;

        public ICommand NavAboutCommand => _navAboutCommand ?? (_navAboutCommand = new DelegateCommand(OnNavAbout));

        public async void OnNavAbout()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("About", navParams);
        }

        private ICommand _navSettingsCommand;

        public ICommand NavSettingsCommand => _navSettingsCommand ?? (_navSettingsCommand = new DelegateCommand(OnNavSettings));

        public async void OnNavSettings()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("Settings", navParams);
        }
        #endregion
    }
}
