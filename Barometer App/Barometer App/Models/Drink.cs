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
        public string BarName { get; set; }

        public string DrinksName { get; set; }

        public double Price { get; set; }
    }
}