using System.Windows.Input;
using Barometer_App.ViewModels;
using Barometer_App;
using Prism.Commands;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public string username { get; set; }
        public string password { get; set; }

        private IdentityService _apiService = new IdentityService();

        private readonly INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService) : base()
        {
            _navigationService = navigationService;
            Title = "Login";
        }

        #region NavCommands
        
        private ICommand _navSignupCommand;

        public ICommand NavSignupCommand =>
            _navSignupCommand ?? (_navSignupCommand = new DelegateCommand(OnNavSignup));

        public async void OnNavSignup()
        {
            await _navigationService.NavigateAsync("Signup");
        }
        #endregion

        #region Commands

        private ICommand _loginCommand;

        public ICommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(OnLoginCommand));

        public async void OnLoginCommand()
        {
            LoginDTO dto = new LoginDTO()
            {
                Username = username,
                Password = password,
            };

            string token = await _apiService.LoginAsync(dto);

            if (token != null)
            {
                NavigationParameters navParams = new NavigationParameters();
                navParams.Add("token", token);

                await _navigationService.GoBackAsync(navParams);
            }
            else
                await App.Current.MainPage.DisplayAlert("Error", "Something went wrong in the login!", "OK");

        }

        #endregion
    }
}