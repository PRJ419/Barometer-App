using System.Windows.Input;
using Barometer_App.ViewModels;
using Prism.Commands;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    public class SignupViewModel : ViewModelBase
    {
        public INavigationService NavigationService { get; }
        public SignupViewModel(INavigationService navigationService) : base()
        {
            Title = "Sign Up";
            NavigationService = navigationService;
        }

        #region Commands

        private ICommand _navigateToBarSignUpCommand;

        public ICommand NavigateToBarSignUpCommand =>
            _navigateToBarSignUpCommand ?? (_navigateToBarSignUpCommand = new DelegateCommand(OnNavigateToBarSignUp));

        public async void OnNavigateToBarSignUp()
        {
            await NavigationService.NavigateAsync("BarSignup");
        }

        #endregion
    }
}