using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace Barometer_App.Models
{
    /// <summary>
    /// Model representation of drinks that a bar offers
    /// </summary>
    public class Drink : BindableBase
    {
        /// <summary>
        /// Private string for holding the name of the bar offering the drink
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
        /// Private string for holding the name of the drink being offered
        /// </summary>
        private string _drinksName;

        /// <summary>
        /// Bindable property for accessing the _drinksName private
        /// </summary>
        public string DrinksName
        {
            get => _drinksName;
            set => SetProperty(ref _drinksName, value);
        }

        /// <summary>
        /// Private double for holding the price of the drink being offered
        /// </summary>
        private double _price;

        /// <summary>
        /// Bindable property for accessing the _price private
        /// </summary>
        public double Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        /// <summary>
        /// Private string for holding the URI of the image of the drink
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