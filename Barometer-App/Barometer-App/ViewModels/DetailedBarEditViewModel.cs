using System.Windows.Input;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    /// <summary>
    /// ViewModel for the DetailedBarEditView View
    /// </summary>
    public class DetailedBarEditViewModel : ViewModelBase
    {
        private User customer;
        /// <summary>
        /// Private property for the bindable property bar
        /// </summary>
        private Bar _bar;

        /// <summary>
        /// Bindable property for accessing the Bar
        /// </summary>
        public Bar Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }       

        /// <summary>
        /// Constructor. Makes an instance of the bar for the view to work,
        ///  sets title, and sets NavigationService. 
        /// </summary>
        /// <param name="navigationService"></param>
        public DetailedBarEditViewModel(INavigationService navigationService)
        {
            Bar = new Bar();
            Title = "Detailed Bar Editing Page";
            NavigationService = navigationService;
            customer = User.GetCustomer();
        }

        /// <summary>
        /// Loads the bar to edit.
        /// TODO: This needs to not be hard coded. 
        /// </summary>
        /// <param name="parameters"></param>
        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            Bar = await RestClient.GetDetailedBar(customer.FavoriteBar);
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
        /// Sends the data to the server and navigates back to the last view. 
        /// </summary>
        private async void SaveExecute()
        {
            await RestClient.EditBar(Bar);
            await NavigationService.GoBackAsync();
        }
    }
}