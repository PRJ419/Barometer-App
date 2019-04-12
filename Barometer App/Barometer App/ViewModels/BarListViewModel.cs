using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;


namespace Barometer_App.ViewModels
{
    public class BarListViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ObservableCollection<BarSimple> Bars { get; set; }

        public IRestClient RestClient { get; set; }

        public BarListViewModel(INavigationService navigationService)
        {
            Bars = new ObservableCollection<BarSimple>();
            RestClient = new RestClient();
            _navigationService = navigationService;
            Title = "Awesome Bar list";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            OnLoadItemsCommand();
        }


        #region Propertis

        private BarSimple _currentBar = null;

        public BarSimple CurrentBar
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

        private async void OnLoadItemsCommand()
        {
            Bars.Clear();
            CurrentBar = null;
            var barList =await  RestClient.GetBestBarList();
            foreach (var barSimple in barList)
            {
                Bars.Add(barSimple); 
            }
        }

        private ICommand _navigationCommand;

        public ICommand NavigationCommand =>
             _navigationCommand ?? (_navigationCommand = new DelegateCommand(NavigateViaListView));

        public async void NavigateViaListView()
        {           
            var navParam = new NavigationParameters {{"Bar", CurrentBar.BarName}};
            CurrentBar = null;
            await _navigationService.NavigateAsync("DetailedBar", navParam);
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
            List<BarSimple> tempBars;

            switch (obj)
            {
                case "BarName":
                    tempBars = Bars.OrderBy(o => o.BarName).ToList();
                    break;
                case "AvgRating":
                    tempBars = Bars.OrderBy(o => o.AvgRating).ToList();
                    //Highest rating first
                    tempBars.Reverse();
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