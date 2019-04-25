using System.Windows.Input;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    /// <summary>
    /// ViewModel for the BarSignup View
    /// </summary>
    public class BarSignupViewModel : ViewModelBase
    {
        /// <summary>
        /// Property for hold the incoming bar object information
        /// </summary>
        private Bar _bar;

        /// <summary>
        /// Bindable property for the View
        /// </summary>
        public Bar Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }

        /// <summary>
        /// Navigation service for navigation of the views
        /// </summary>
        private readonly INavigationService _nav;

        /// <summary>
        /// RestClient for later use
        /// </summary>
        private readonly IRestClient _restClient;

        /// <summary>
        /// Constructor for the ViewModel of the BarSignup View
        /// Initializes Bar and RestClient
        /// </summary>
        /// <param name="navigationService">
        /// Navigation service provided by Prism
        /// </param>
        public BarSignupViewModel(INavigationService navigationService)
        {
            _nav = navigationService;
            Bar = new Bar();
            _restClient = new RestClient();
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _signUpCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand SignUpCommand => _signUpCommand ?? (_signUpCommand = new DelegateCommand(OnSignUp));

        /// <summary>
        /// Logic that defines the behaviour for the Signup command
        /// </summary>
        private async void OnSignUp()
        {
           await _restClient.CreateBar(Bar);
        }

    }
}