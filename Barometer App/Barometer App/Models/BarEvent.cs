using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace Barometer_App.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class BarEvent : BindableBase
    {
        public string BarName { get; set; }

        public string EventName { get; set; }

        public DateTime Date { get; set; }
    }
}
