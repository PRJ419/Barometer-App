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

        private readonly INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Bar-O-Meter";
            Bars = new ObservableCollection<Bar>(new List<Bar>(){
                new Bar()
                {Name = "Dat Bar", Address = "Peter Bøgh", BarId = 1,
                    CVR = "21312213", Email = "Dat@bar.dk", Image = "chess.png",
                    AboutText = "Datbar sutter", Rating = 12
                },
                new Bar()
                {
                    Name = "Katrines kælder", Address = "Katrionebjerg", BarId = 0,
                    CVR = "21203050", Email = "KK@kk.dk", Image = "katrine.png",
                    AboutText = "Katrines kælder er fredagsbar for ingeniørene på katrinebjerg.", Rating = 14
                }
            });
        }



        #region Commands

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
            navParams.Add("Bar", Bars[1]);

            await _navigationService.NavigateAsync("BarEdit", navParams);
        }

        private ICommand _navSignupCommand;

        public ICommand NavSignupCommand => _navSignupCommand ?? (_navSignupCommand = new DelegateCommand(OnNavSignUp));

        public async void OnNavSignUp()
        {
            var navParams = new NavigationParameters();
            navParams.Add("Bar", Bars[1]);

            await _navigationService.NavigateAsync("DetailedBar", navParams);
        }
        #endregion
    }
}
