using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Barometer_App.Models;
using Prism.DryIoc;

namespace Barometer_App.Models
{
    /// <summary>
    /// Implementation of the Alerter interface
    /// </summary>
    public class Alerter : IAlerter
    {
        /// <summary>
        /// Alert method that calls the PrismApplications DisplayAlert
        /// </summary>
        /// <param name="title"> The title of the Alert </param>
        /// <param name="message"> The message of the Alert </param>
        /// <param name="cancel"> The cancel option text </param>
        /// <returns></returns>
        public async Task Alert(string title, string message, string cancel)
        {
            await PrismApplication.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        /// <summary>
        /// Alert method that calls the PrismApplications DisplayAlert
        /// </summary>
        /// <param name="title"> The title of the Alert  </param>
        /// <param name="message"> The message of the Alert  </param>
        /// <param name="accept"> The accept option text </param>
        /// <param name="cancel"> The cancel option text </param>
        /// <returns></returns>
        public async Task<bool> Alert(string title, string message, string accept, string cancel)
        {
            return await PrismApplication.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
