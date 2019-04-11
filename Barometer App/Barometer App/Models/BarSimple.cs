using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace RESTClient.DTOs
{
    
        /// <summary>
        /// Transfer object for the listview of bars
        /// </summary>
        public class BarSimple : BindableBase
        {
            // Max length 150
            private string _barName;
            public string BarName
            {
                get => _barName;
                set => SetProperty(ref _barName, value);
            }

            // AvgRating from 0.0 to 5.0
            private double _avgRating;

            public double AvgRating
            {
                get => _avgRating;
                set => SetProperty(ref _avgRating, value/5);
            }

            // max length 500
            private string _shortDescription;

            public string ShortDescription
            {
                get => _shortDescription;
                set => SetProperty(ref _shortDescription, value);
            }

        private string _image;

        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

    }
    
}
