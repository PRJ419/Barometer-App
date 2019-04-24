using Barometer_App.ViewModels;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    /// <summary>
    /// Viewmodel class for the About View.
    /// </summary>
    public class AboutViewModel : ViewModelBase
    {
        /// <summary>
        /// Constructor for Viewmodel which sets the Title attritube from ViewModelBase.
        /// </summary>
        /// <param name="navigationService">
        /// A reference to the navigationService object provided by Prism
        /// </param>
        public AboutViewModel(INavigationService navigationService) : base()
        {
            Title = "About";
        }
    }
}