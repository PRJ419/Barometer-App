using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;
using RESTClient.DTOs;

namespace Barometer_App.ViewModels
{
    public class BarListViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ObservableCollection<BarListViewDto> Bars { get; set; }

        public IRestClient RestClient { get; set; }

        public BarListViewModel(INavigationService navigationService)
        {
            Bars = new ObservableCollection<BarListViewDto>();
            RestClient = new StubRestClient();
            OnLoadItemsCommand();
            _navigationService = navigationService;
            Title = "Awesome Bar list";
        }

        #region Propertis

        private BarListViewDto _currentBar = null;

        public BarListViewDto CurrentBar
        {
            get => _currentBar;
            set => SetProperty(ref _currentBar, value);
        }

        #endregion

        #region Commands

        private ICommand _loadItemsCommand;
        public ICommand LoadItemsCommand =>
            _loadItemsCommand ??
            (_loadItemsCommand = new DelegateCommand(OnLoadItemsCommand));

        private void OnLoadItemsCommand()
        {
            CurrentBar = null;
            var barList = RestClient.GetBarList();
            foreach (var barSimpleDto in barList.Result)
            {
                Bars.Add(new BarListViewDto() {
                    ShortDescription = barSimpleDto.ShortDescription,
                    AvgRating = barSimpleDto.AvgRating/5,
                    BarName = barSimpleDto.BarName,
                    Image = "katrine.png"
                });
            }
        }

        private ICommand _navigationCommand;

        public ICommand NavigationCommand =>
             _navigationCommand ?? (_navigationCommand = new DelegateCommand(NavigateViaListView));

        public async void NavigateViaListView()
        { 
            CurrentBar = null;
            await _navigationService.NavigateAsync("DetailedBar");
        }

        private ICommand _filterItemsCommand;

        public ICommand FilterItemsCommand
        {
            get
            {
                return _filterItemsCommand ?? (_filterItemsCommand =
                    new DelegateCommand<string>(FilterItemsExecute, FilterItemsCanExecute).ObservesProperty(() => Bars.Count)
                );
            }
        }

        public bool FilterItemsCanExecute(string obj)
        {
            return obj != null;
        }

        public void FilterItemsExecute(string obj)
        {
            List<BarListViewDto> tempBars;

            switch (obj)
            {
                case "Name":
                    tempBars = Bars.OrderBy(o => o.BarName).ToList();
                    break;
                case "Rating":
                    tempBars = Bars.OrderBy(o => o.AvgRating).ToList();
                    //Highest rating first
                    tempBars.Reverse();
                    break;
                case "Postal Code":
                    tempBars = Bars.OrderBy(o => o.PostalCode).ToList();
                    break;
                default:
                    throw new InvalidEnumArgumentException("Couldn't find the item");
            }

            Bars.Clear();

            foreach (var bar in tempBars)
            {
                Bars.Add(bar);
            }
        }

        #endregion


    }
}