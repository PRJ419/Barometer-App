using System.Windows.Input;
using Barometer_App.ViewModels;
using Prism.Commands;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private readonly INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService) : base()
        {
            Title = "Login";
        }

        #region NavCommands
        
        private ICommand _navSignupCommand;

        public ICommand NavSignupCommand =>
            _navSignupCommand ?? (_navSignupCommand = new DelegateCommand(OnNavSignup));

        public async void OnNavSignup()
        {
            var navParams = new NavigationParameters();
            await _navigationService.NavigateAsync("Signup", navParams);
        }
        #endregion

        #region Commands

        #endregion
    }
}