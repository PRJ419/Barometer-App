using System;
using System.Collections.Generic;
using System.Text;

namespace Barometer_App.Models
{
    /// <summary>
    /// Class for holding the information of a BarRepresentative
    /// </summary>
    public class BarRepresentative
    {
        /// <summary>
        /// Public string holding the UserName
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Public string for holding the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Public string for holding the name of the bar associated with the BarRepresentative
        /// </summary>
        public string BarName { get; set; }
    }
}