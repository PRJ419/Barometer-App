using System.Collections.ObjectModel;
using System.Windows.Input;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    public class DetailedBarEditViewModel : ViewModelBase
    {
        private Bar _bar;

        public Bar Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }       

        public DetailedBarEditViewModel(INavigationService navigationService)
        {
            Bar = new Bar();
            Title = "Detailed Bar Editing Page";
            NavigationService = navigationService;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            Bar = await RestClient.GetDetailedBar("Barname");
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(SaveExecute));

        private async void SaveExecute()
        {
            await RestClient.EditBar(Bar);
            await NavigationService.GoBackAsync();
        }
    }
}