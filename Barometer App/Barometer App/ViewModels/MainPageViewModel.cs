using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Barometer_App.Models;

namespace Barometer_App.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Bar> Bars { get; set; }

        public bool LoggedIn { get; set; } = false;

        private readonly INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Bar-O-Meter";
        }



        #region NavCommands

        private ICommand _navShowBarsCommand;

        public ICommand NavShowBarsCommand => _navShowBarsCommand ?? (_navShowBarsCommand = new DelegateCommand(OnNavShowBars));

        public async void OnNavShowBars()
        {

            await _navigationService.NavigateAsync("BarList");
        }

        private ICommand _navLoginCommand;

        public ICommand NavLoginCommand => _navLoginCommand ?? (_navLoginCommand = new DelegateCommand(OnNavLogin));


        public async void OnNavLogin()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("Login", navParams);
        }

        private ICommand _navSignupCommand;

        public ICommand NavSignupCommand => _navSignupCommand ?? (_navSignupCommand = new DelegateCommand(OnNavSignUp));

        public async void OnNavSignUp()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("Signup", navParams);
        }

        private ICommand _navAboutCommand;

        public ICommand NavAboutCommand => _navAboutCommand ?? (_navAboutCommand = new DelegateCommand(OnNavAbout));

        public async void OnNavAbout()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("About", navParams);
        }

        private ICommand _navSettingsCommand;

        public ICommand NavSettingsCommand => _navSettingsCommand ?? (_navSettingsCommand = new DelegateCommand(OnNavSettings));

        public async void OnNavSettings()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("Settings", navParams);
        }
        #endregion

        #region Commands

        #endregion
    }
}
