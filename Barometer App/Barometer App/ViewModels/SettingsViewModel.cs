using Barometer_App.ViewModels;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(INavigationService navigationService) : base()
        {
            Title = "Settings";
        }
    }
}
