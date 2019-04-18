using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    class SettingsViewModel : ViewModelBase
    {
        private string _barToDelete;

        public string BarToDelete { get => _barToDelete; set => SetProperty(ref _barToDelete, value); }

        private readonly IRestClient _restClient;
        private readonly INavigationService _navigationService;

        public SettingsViewModel(INavigationService navigationService) : base()
        {
            Title = "Settings";
            _restClient = new RestClient();
            _navigationService = navigationService;
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new DelegateCommand(OnDeleteCommand));

        private async void OnDeleteCommand()
        {
            await _restClient.DeleteBar(BarToDelete);
            await _navigationService.GoBackAsync();
        }
    }
}
