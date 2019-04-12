using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace Barometer_App.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Drink : BindableBase
    {
        private string _barName;
        public string BarName
        {
            get => _barName;
            set => SetProperty(ref _barName, value);
        }

        private string _drinksName;
        public string DrinksName
        {
            get => _drinksName;
            set => SetProperty(ref _drinksName, value);
        }

        private double _price;
        public double Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private string _image;
        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }
    }
}