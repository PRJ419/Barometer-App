using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Barometer_App.Models
{
    public interface IAlerter
    {
        Task Alert(string title, string message, string cancel);
        Task Alert(string title, string message, string accept, string cancel);
    }
}
