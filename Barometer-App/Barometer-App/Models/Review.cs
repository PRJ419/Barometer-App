using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;
using RESTClient;

namespace Barometer_App.Models
{
    /// <summary>
    /// Model representation of a Review given by a User for a Bar
    /// </summary>
    public class Review
    {
        /// <summary>
        /// 
        /// </summary>
        public int BarPressure { get; set; }

        public string BarName { get; set; }

        public string Username { get; set; }
    }
}
