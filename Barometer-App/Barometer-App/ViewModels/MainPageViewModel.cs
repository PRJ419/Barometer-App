using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Barometer_App.Models;
using Prism;
using Xamarin.Forms;

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
        /// Alerter used for popups
        /// </summary>
        private IAlerter Alerter;

        /// <summary>
        /// Private version of the bindable property for the ViewModel to hold
        /// </summary>
        private User _customer;

        /// <summary>
        /// Public bindable Customer class for the View to bind to and access login status from
        /// </summary>
        public User Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        /// <summary>
        /// Constructor for the ViewModel for the MainMenu View
        /// It sets the Title and loads the Customer into the application
        /// </summary>
        /// <param name="navigationService">
        /// A reference to the navigationService object provided by Prism
        /// </param>
        public MainPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Title = "Bar-O-Meter";

            //Load this in later
            Customer = User.GetCustomer();

            Alerter = new Alerter();
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
        public async void OnLogout()
        {
            bool result = await Alerter.Alert(
                "Confirmation",
                "Are you sure you want to log out?",
                "Yes",
                "No");
            if (result)
            {
                Customer.UserToken = null;
                Customer.IsBarRep = false;

                Application.Current.Properties["Token"] = Customer.UserToken;
                Application.Current.Properties["Username"] = Customer.UserName;
            }
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _navToMyBarCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand NavToMyBarCommand => _navToMyBarCommand ?? (_navToMyBarCommand = new DelegateCommand<string>(OnNavToMyBar));

        /// <summary>
        /// Logic that defines behaviour for the navigation to my bar
        /// </summary>
        public async void OnNavToMyBar(string navTo)
        {
            var navParams = new NavigationParameters();
            navParams.Add("Bar", Customer.FavoriteBar);

            await NavigationService.NavigateAsync(navTo, navParams);
        }
    }
}
