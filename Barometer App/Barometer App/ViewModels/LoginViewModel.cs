using System.Windows.Input;
using Barometer_App.DTO;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    /// <summary>
    /// A ViewModel for the Login View
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        /// <summary>
        /// Property for the View to bind to
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Property for the View to bind to
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// RestClient for communication to application server.
        /// Includes Identity and regular API calls through HTTPS.
        /// </summary>
        private RestClient _apiService = new RestClient();

        /// <summary>
        /// Navigation Service provided by Prism, which is later used for navigation to other Views and popping back to earlier Views when logged in.
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Constructor for ViewModel, this sets Title for binding and _navigationService for later use.
        /// </summary>
        /// <param name="navigationService">
        /// A reference to the navigationService object provided by Prism
        /// </param>
        public LoginViewModel(INavigationService navigationService) : base()
        {
            _navigationService = navigationService;
            Title = "Login";
        }

        #region NavCommands

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _navSignupCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand NavSignupCommand =>
            _navSignupCommand ?? (_navSignupCommand = new DelegateCommand(OnNavSignup));

        /// <summary>
        /// Logic that defines behaviour for the Signup navigation
        /// </summary>
        public async void OnNavSignup()
        {
            await _navigationService.NavigateAsync("Signup");
        }
        #endregion

        #region Commands

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _loginCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(OnLoginCommand));

        /// <summary>
        /// Logic that defines the behaviour for the Login command.
        /// This uses the _apiService to LoginAsync with a LoginDTO, it also displays an error if something goes wrong and updates the Customer object if login is successful
        /// </summary>
        public async void OnLoginCommand()
        {
            Customer customer = Customer.GetCustomer();

            if (!customer.LoggedIn)
            {
                LoginDTO dto = new LoginDTO()
                {
                    Username = username,
                    Password = password,
                };

                string token = await _apiService.LoginAsync(dto);

                if (token != null)
                {
                    customer.UserToken = token;
                    await _navigationService.GoBackAsync();
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "Something went wrong in the login!", "OK");
            }

        }

        #endregion
    }
}