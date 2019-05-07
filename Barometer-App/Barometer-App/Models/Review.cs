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
        /// Property for holding holding the rating of the review of the bar
        /// </summary>
        public int BarPressure { get; set; }

        /// <summary>
        /// Property for holding the name of the bar being reviewed
        /// </summary>
        public string BarName { get; set; }

        /// <summary>
        /// Property for holding the name of the user doing the review
        /// </summary>
        public string Username { get; set; }
    }
}
