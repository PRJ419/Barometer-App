using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Barometer_App.Models;
using Prism.DryIoc;

namespace Barometer_App.Models
{
    public class Alerter : IAlerter
    {
        public async Task Alert(string title, string message, string cancel)
        {
            await PrismApplication.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task Alert(string title, string message, string accept, string cancel)
        {
            await PrismApplication.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
