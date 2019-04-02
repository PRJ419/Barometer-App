using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    public class BarListViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ObservableCollection<Bar> Bars { get; set; }


        public BarListViewModel(INavigationService navigationService)
        {
            Bars = new ObservableCollection<Bar>();
            _navigationService = navigationService;
            Title = "Awesome Bar list";         
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            var bars = parameters.GetValue<ObservableCollection<Bar>>("Bars");
            foreach (var bar in bars)
            {
                Bars.Add(bar);
            }
        }

        #region Propertis

        private Bar _currentBar = null;

        public Bar CurrentBar
        {
            get => _currentBar;
            set
            {
                SetProperty(ref _currentBar, value);
            } 
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
        }

        private ICommand _navigationCommand;

        public ICommand NavigationCommand =>
             _navigationCommand ?? (_navigationCommand = new DelegateCommand(NavigateViaListView));

        public async void NavigateViaListView()
        {
            var navParams = new NavigationParameters {{"Bar", _currentBar}};
            CurrentBar = null;
            await _navigationService.NavigateAsync("DetailedBar", navParams);
        }


        private ICommand _detailedBarNavCommand;
        public ICommand DetailedBarNavCommand =>
            _detailedBarNavCommand ??
            (_detailedBarNavCommand = new DelegateCommand(OnDetailedBarNavCommand));

        private void OnDetailedBarNavCommand()
        {

        }

        private ICommand _filterItemsCommand;

        public ICommand FilterItemsCommand {
            get {
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
            List<Bar> tempBars;

            switch (obj)
            {
                case "Name":
                    tempBars = Bars.OrderBy(o => o.Name).ToList();
                    break;
                case "Rating":
                    tempBars = Bars.OrderBy(o => o.Rating).ToList();
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