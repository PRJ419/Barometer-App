using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    public class BarEditsMenuViewModel : ViewModelBase
    {
        public BarEditsMenuViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Title = "Edit Menu";
        }
    }
}