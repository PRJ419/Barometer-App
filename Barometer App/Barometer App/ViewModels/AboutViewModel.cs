using Barometer_App.ViewModels;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        public AboutViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}