using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    /// <summary>
    /// A ViewModel for the SettingsView
    /// </summary>
    class SettingsViewModel : ViewModelBase
    {
        /// <summary>
        /// RestClient for use in communication with the application server through HTTPS
        /// </summary>
        private readonly IRestClient _restClient;

        /// <summary>
        /// Navigation Service provided by Prism
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Constructor for Viewmodel which sets the Title
        /// </summary>
        /// <param name="navigationService">
        /// A reference to the navigationService object provided by Prism
        /// </param>
        public SettingsViewModel(INavigationService navigationService) : base()
        {
            Title = "Settings";
            _restClient = new RestClient();
            _navigationService = navigationService;
        }

        /*
        private string _barToDelete;

        public string BarToDelete { get => _barToDelete; set => SetProperty(ref _barToDelete, value); }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new DelegateCommand(OnDeleteCommand));

        private async void OnDeleteCommand()
        {
            await _restClient.DeleteBar(BarToDelete);
            await _navigationService.GoBackAsync();
        }
        */
    }
}
