using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    /// <summary>
    /// A ViewModel for the SettingsView
    /// </summary>
    class SettingsViewModel : ViewModelBase
    {
        /// <summary>
        /// Constructor for Viewmodel which sets the Title
        /// </summary>
        /// <param name="navigationService">
        /// A reference to the navigationService object provided by Prism
        /// </param>
        public SettingsViewModel(INavigationService navigationService) : base()
        {
            Title = "Settings";
            NavigationService = navigationService;
        }
    }
}
