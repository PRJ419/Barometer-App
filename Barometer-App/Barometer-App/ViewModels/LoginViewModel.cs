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
        public string Username { get; set; }

        /// <summary>
        /// Property for the View to bind to
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Constructor for ViewModel, this sets Title for binding and _navigationService for later use.
        /// </summary>
        /// <param name="navigationService">
        /// A reference to the navigationService object provided by Prism
        /// </param>
        public LoginViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
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
            await NavigationService.NavigateAsync("Signup");
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
            User customer = User.GetCustomer();

            if (!customer.LoggedIn)
            {
                LoginDTO dto = new LoginDTO()
                {
                    Username = Username,
                    Password = Password,
                };

                string token = await RestClient.LoginAsync(dto);

                if (token != null)
                {
                    customer.UserToken = token;
                    customer.UserName = Username;
                    await NavigationService.GoBackAsync();
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "Something went wrong in the login!", "OK");
            }

        }

        #endregion
    }
}