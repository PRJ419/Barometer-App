using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace Barometer_App.Models
{
    /// <summary>
    /// Model representation of the Bar Events
    /// </summary>
    public class BarEvent : BindableBase
    {
        /// <summary>
        /// Private string for holding the name of the bar hosting the event
        /// </summary>
        private string _barName;

        /// <summary>
        /// Bindable property for accessing the _barName private
        /// </summary>
        public string BarName
        {
            get => _barName;
            set => SetProperty(ref _barName, value);
        }

        /// <summary>
        /// Private string for holding the name of the event
        /// </summary>
        private string _eventName;

        /// <summary>
        /// Bindable property for accessing the _eventName private
        /// </summary>
        public string EventName
        {
            get => _eventName;
            set => SetProperty(ref _eventName, value);
        }

        /// <summary>
        /// Private DateTime for holding the date of the event
        /// </summary>
        private DateTime _date;

        /// <summary>
        /// Bindable property for accessing the _date private
        /// </summary>
        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        /// <summary>
        /// Private string for holding the URI for the image associated with the bar
        /// </summary>
        private string _image;

        /// <summary>
        /// Bindable property for accessing the _image private
        /// </summary>
        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }
    }
}
