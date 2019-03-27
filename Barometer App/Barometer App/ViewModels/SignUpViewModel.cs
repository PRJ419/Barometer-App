using Barometer_App.ViewModels;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    public class SignupViewModel : ViewModelBase
    {
        public SignupViewModel(INavigationService navigationService) : base()
        {
            Title = "Sign Up";
        }
    }
}