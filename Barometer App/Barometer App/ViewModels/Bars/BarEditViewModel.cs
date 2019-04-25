using System.Windows.Input;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;


namespace Barometer_App.ViewModels
{
    /// <summary>
    /// ViewModel for the BarEdit View
    /// </summary>
    public class BarEditViewModel : ViewModelBase
    {
        /// <summary>
        /// Navigation service for later use
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// RestClient for later use
        /// </summary>
        private readonly IRestClient _restClient;

        /// <summary>
        /// Constructor for the ViewModel for the BarEditViewModel
        /// </summary>
        /// <param name="navigationService">
        /// Navigation service provided by Prism
        /// </param>
        public BarEditViewModel(INavigationService navigationService)
        {
            Title = "Bar Editing Page";          
            _navigationService = navigationService;
            Bar = new Bar();
            _restClient = new RestClient();
            GetBar();
        }

        /// <summary>
        /// Method to retrieve a detailed bar view from the application server
        /// </summary>
        private async void GetBar()
        {
            Bar = await _restClient.GetDetailedBar("cbar");
        }

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
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _saveCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(SaveExecute));

        /// <summary>
        /// Logic for the behaviour of saving the bar information
        /// </summary>
        private async void SaveExecute()
        {
           await _restClient.EditBar(Bar);
           await _navigationService.GoBackAsync();
        }

    }
}
