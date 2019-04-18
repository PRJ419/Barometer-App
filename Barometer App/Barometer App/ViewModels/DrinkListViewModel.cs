using System.Collections.ObjectModel;
using Barometer_App.Models;
using Barometer_App.Views;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    public class DrinkListViewModel : ViewModelBase
    {
        public ObservableCollection<Drink> Drinks { get; set; }
        public DrinkListViewModel()
        {
            Drinks = new ObservableCollection<Drink>();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var param = parameters.GetValue<string>("Bar");
            Title = param + "'s Drinks";
            LoadItems(param);
        }

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