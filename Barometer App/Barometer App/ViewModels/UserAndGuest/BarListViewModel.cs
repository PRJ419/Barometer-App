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
    /// <summary>
    /// ViewModel for the BarList View
    /// </summary>
    public class BarListViewModel : ViewModelBase
    {
        /// <summary>
        /// Navigation service for navigation of the views
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Bindable collection that holds the bars shown
        /// </summary>
        public ObservableCollection<BarSimple> Bars { get; set; }

        /// <summary>
        /// Constructor for the ViewModel for the BarList View
        /// </summary>
        /// <param name="navigationService">
        /// Navigation service provided by Prism
        /// </param>
        public BarListViewModel(INavigationService navigationService)
        {         
            Bars = new ObservableCollection<BarSimple>();
            _navigationService = navigationService;
            Title = "Bar list";
        }

        /// <summary>
        /// Override of the OnNavigatedTo method from INavigationAware
        /// Calls the helper method to load bars
        /// </summary>
        /// <param name="parameters">
        /// 
        /// </param>
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            OnLoadItemsCommand();
        }

        #region Propertis

        /// <summary>
        /// Property for holding the currently selected bar
        /// </summary>
        private BarSimple _currentBar = null;

        /// <summary>
        /// Bindable property for accessing the currently selected bar
        /// </summary>
        public BarSimple CurrentBar
        {
            get => _currentBar;
            set => SetProperty(ref _currentBar, value);
        }

        #endregion

        #region Commands

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _loadItemsCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand LoadItemsCommand =>
            _loadItemsCommand ??
            (_loadItemsCommand = new DelegateCommand(OnLoadItemsCommand));

        /// <summary>
        /// Logic that defines the loading behaviour for the BarList
        /// </summary>
        private async void OnLoadItemsCommand()
        {
            Bars.Clear();
            CurrentBar = null;
            var barList = await RestClient.GetBestBarList();
            foreach (var barSimple in barList)
            {
                Bars.Add(barSimple); 
            }
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _navigationCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand NavigationCommand =>
             _navigationCommand ?? (_navigationCommand = new DelegateCommand(NavigateViaListView));

        /// <summary>
        /// Logic that defines behaviour navigation via selection in the listview
        /// </summary>
        public async void NavigateViaListView()
        {           
            var navParam = new NavigationParameters {{"Bar", CurrentBar.BarName}};
            CurrentBar = null;
            await _navigationService.NavigateAsync("DetailedBar", navParam);
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _filterItemsCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand FilterItemsCommand
        {
            get
            {
                return _filterItemsCommand ?? (_filterItemsCommand =
                    new DelegateCommand<string>(FilterItemsExecute, FilterItemsCanExecute).ObservesProperty(() => Bars.Count)
                );
            }
        }

        /// <summary>
        /// Check for whether a filtering can occur
        /// </summary>
        public bool FilterItemsCanExecute(string obj)
        {
            return obj != null;
        }

        /// <summary>
        /// Logic that defines behaviour for the sorting of the items
        /// Does this by ordering bars in a seperate list and overriding the original afterwards
        /// </summary>
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