using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace Barometer_App.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Review : BindableBase
    {
        public int BarPressure { get; set; }

        public string BarName { get; set; }

        public string Username { get; set; }
    }
}
