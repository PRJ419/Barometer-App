using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace Barometer_App.Models
{

    /// <summary>
    /// Transfer object for the listview of bars
    /// </summary>
    public class BarSimple : BindableBase
    {
        // Max length 150
        /// <summary>
        /// Private string for holding the name of the bar
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

        // AvgRating from 0.0 to 5.0
        /// <summary>
        /// Private double for holding the average rating of the bar
        /// </summary>
        private double _avgRating;

        /// <summary>
        /// Bindable property for accessing the _avgRating private
        /// </summary>
        public double AvgRating
        {
            get => _avgRating;
            set => SetProperty(ref _avgRating, value);
        }

        // max length 500
        /// <summary>
        /// Private string holding the short description of the bar
        /// </summary>
        private string _shortDescription;

        /// <summary>
        /// Bindable property for accessing the _shortDescription private
        /// </summary>
        public string ShortDescription
        {
            get => _shortDescription;
            set => SetProperty(ref _shortDescription, value);
        }

        /// <summary>
        /// Private string holding the URI for the image associated with the bar
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
