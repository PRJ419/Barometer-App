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
            Bars = new ObservableCollection<Bar>(new List<Bar>(){
                new Bar()
                {Name = "Dat Bar", Address = "Peter Bøgh", BarId = 1,
                    CVR = "21312213", Email = "Dat@bar.dk", Image = "chess.png",
                    AboutText = "Datbar sutter", Rating = 0.6
                },
                new Bar()
                {
                    Name = "Katrines kælder", Address = "Katrionebjerg", BarId = 0,
                    CVR = "21203050", Email = "KK@kk.dk", Image = "katrine.png",
                    AboutText = "Katrines kælder er fredagsbar for ingeniørene på katrinebjerg.", Rating = 0.9, LongAboutText = "The BackButtonTitle, Title, TitleIcon, and TitleView properties can all define values that occupy space on the navigation bar. While the navigation bar size varies by platform and screen size, setting all of these properties will result in conflicts due to the limited space available. Instead of attempting to use a combination of these properties, you may find that you can better achieve your desired navigation bar design by only setting the TitleView property."
                }
            });
        }



        #region NavCommands

        private ICommand _navShowBarsCommand;

        public ICommand NavShowBarsCommand => _navShowBarsCommand ?? (_navShowBarsCommand = new DelegateCommand(OnNavShowBars));

        public async void OnNavShowBars()
        {
            var navParams = new NavigationParameters();
            navParams.Add("Bars", Bars);

            await _navigationService.NavigateAsync("BarList", navParams);
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
