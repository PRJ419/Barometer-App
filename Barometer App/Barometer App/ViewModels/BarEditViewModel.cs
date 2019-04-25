using System.Windows.Input;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    /// <summary>
    /// ViewModel for the BarEdit View
    /// </summary>
    public class BarEditViewModel : ViewModelBase
    {
        /// <summary>
        /// Constructor for the ViewModel for the BarEditViewModel
        /// </summary>
        /// <param name="navigationService">
        /// Navigation service provided by Prism
        /// </param>
        public BarEditViewModel(INavigationService navigationService)
        {
            Title = "Bar Editing Page";          
            NavigationService = navigationService;
            Bar = new Bar();
            GetBar();
        }

        /// <summary>
        /// Method to retrieve a detailed bar view from the application server
        /// bug: we need a way to access the correct data here
        /// </summary>
        private async void GetBar()
        {
            Bar = await RestClient.GetDetailedBar("");
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
           await RestClient.EditBar(Bar);
           await NavigationService.GoBackAsync();
        }

    }
}
