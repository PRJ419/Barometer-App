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

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _navToBarListEditCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand NavToBarListEditCommand => _navToBarListEditCommand ?? (_navToBarListEditCommand = new DelegateCommand(OnNavToBarList));

        /// <summary>
        /// Logic that defines behaviour for the navigation to bar edit
        /// </summary>
        public async void OnNavToBarList()
        {
            await NavigationService.NavigateAsync("BarEdit");
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _navToDetailedBarEditCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand NavToDetailedBarEditCommand => _navToDetailedBarEditCommand ?? (_navToDetailedBarEditCommand = new DelegateCommand(OnNavToDetailedBarEdit));

        /// <summary>
        /// Logic that defines behaviour for the navigation to bar edit
        /// </summary>
        public async void OnNavToDetailedBarEdit()
        {
            await NavigationService.NavigateAsync("DetailedBarEdit");
        }
    }
}