using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Barometer_App.Models
{
    /// <summary>
    /// Interface for the Alerter class
    /// </summary>
    public interface IAlerter
    {
        Task Alert(string title, string message, string cancel);
        Task Alert(string title, string message, string accept, string cancel);
    }
}
