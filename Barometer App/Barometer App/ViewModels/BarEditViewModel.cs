using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Barometer_App.Models;
using Barometer_App.ViewModels;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;
using RESTClient.DTOs;

namespace Barometer_App.ViewModels
{
    public class BarEditViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private readonly IRestClient _restClient;

        public BarEditViewModel(INavigationService navigationService)
        {
            Title = "Bar Editing Page";          
            _navigationService = navigationService;
            Bar = new Bar();
            _restClient = new RestClient();
            GetBar();
        }

        private async void GetBar()
        {
            Bar = await _restClient.GetDetailedBar("cbar");
        }

        private Bar _bar;

        public Bar Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(SaveExecute));

        private async void SaveExecute()
        {
           await _restClient.EditBar(Bar);
           await _navigationService.GoBackAsync();
        }

    }
}
