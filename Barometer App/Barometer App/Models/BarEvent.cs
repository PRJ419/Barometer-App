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
        private string _barName;
        public string BarName
        {
            get => _barName;
            set => SetProperty(ref _barName, value);
        }

        private string _eventName;
        public string EventName
        {
            get => _eventName;
            set => SetProperty(ref _eventName, value);
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        private string _image;

        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }
    }
}
