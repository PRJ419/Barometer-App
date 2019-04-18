using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Barometer_App.Models;
using Barometer_App.Views;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    class EventsViewModel : ViewModelBase
    {
        public ObservableCollection<BarEvent> Events { get; set; }

        public EventsViewModel()
        {
            Events = new ObservableCollection<BarEvent>();            
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var param = parameters.GetValue<string>("Bar");
            LoadDrinks(param);
        }

        private async void LoadDrinks(string barName)
        {
            var data = await RestClient.GetBarEventList(barName);
            foreach (var events in data)
            {
                Events.Add(events);
            }
            Title = data[0].BarName + "'s Events";
        }
    }
}
