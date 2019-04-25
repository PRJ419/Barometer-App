using System.Collections.ObjectModel;
using Barometer_App.Models;
using Barometer_App.Views;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    /// <summary>
    /// ViewModel for hte Drinks View
    /// </summary>
    public class DrinkListViewModel : ViewModelBase
    {
        /// <summary>
        /// Bindable collection for holding the drinks for the currently accessed bar
        /// </summary>
        public ObservableCollection<Drink> Drinks { get; set; }

        /// <summary>
        /// Constructor for the ViewModel of the Drinkslist View
        /// </summary>
        public DrinkListViewModel()
        {
            Drinks = new ObservableCollection<Drink>();
        }

        /// <summary>
        /// Override of OnNavigatedTo from INavigationAware
        /// This loads the Events from the currently accessed bar upon navigation to the View
        /// </summary>
        /// <param name="parameters">
        /// Parameter object which is used to hold the barname
        /// </param>
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var param = parameters.GetValue<string>("Bar");
            Title = param + "'s Drinks";
            LoadItems(param);
        }

        /// <summary>
        /// Loads Drinks for the currently accessed bar based on the supplied name
        /// </summary>
        /// <param name="name">
        /// Barname for use in the query to the application server
        /// </param>
        private async void LoadItems(string name)
        {
            var list = await RestClient.GetBarDrinkList(name);
            foreach (var drink in list)
            {
                Drinks.Add(drink);
            }
        }
    }
}