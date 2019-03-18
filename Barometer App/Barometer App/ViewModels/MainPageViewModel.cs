using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Barometer_App.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Bar-O-Meter";
        }

        #region Commands

        private ICommand _navShowBarsCommand;

        public ICommand NavShowBarsCommand => _navShowBarsCommand ?? (_navShowBarsCommand = new DelegateCommand(OnShowBars));

        async private void OnShowBars()
        {
            await _navigationService.NavigateAsync("BarList");
        }

        #endregion
    }
}
