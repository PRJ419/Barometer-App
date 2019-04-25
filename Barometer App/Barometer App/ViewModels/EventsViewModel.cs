using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Barometer_App.Models;
using Barometer_App.Views;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    /// <summary>
    /// ViewModel for the Events View
    /// </summary>
    class EventsViewModel : ViewModelBase
    {
        /// <summary>
        /// Bindable collection of Events for later use
        /// </summary>
        public ObservableCollection<BarEvent> Events { get; set; }

        /// <summary>
        /// Constructor for the ViewModel
        /// </summary>
        public EventsViewModel()
        {
            Events = new ObservableCollection<BarEvent>();            
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
            LoadEvents(param);
        }

        /// <summary>
        /// Loads Events through the RestClient to populate the list
        /// </summary>
        /// <param name="barName">
        /// String used to make the search query to the application server
        /// </param>
        private async void LoadEvents(string barName)
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
