using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Barometer_App.Models;
using Barometer_App.ViewModels;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    public class BarEditViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private Bar _bar;

        public BarEditViewModel(INavigationService navigationService)
        {
            Title = "Bar Editing Page";          
            _navigationService = navigationService;
            _bar = new Bar();
        }

        public Bar Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            var bar = parameters.GetValue<Bar>("Bar");
            Bar = bar;
        }

    }
}
