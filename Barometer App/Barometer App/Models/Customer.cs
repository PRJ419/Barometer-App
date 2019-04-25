using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Prism.Mvvm;

namespace Barometer_App.Models
{
    public class Customer : BindableBase
    {
        //Singleton pattern to ensure on only customer is logged in
        private static readonly Customer customer = new Customer();
        private Customer() {}

        public static Customer GetCustomer()
        {
            return customer;
        }

        public string UserName { get; set; }
        public string Name { get; set; }
        //Deprecated begin
        public string Email{ get; set; }
        public string Password { get; set; }
        //Deprecated end
        private string usertoken;
        public string UserToken
        {
            get
            {
                return usertoken;
            }
            set
            {
                usertoken = value;
                _LoggedIn = (usertoken != null);
                RaisePropertyChanged("LoggedIn");
            }
        }

        private bool _LoggedIn;
        public bool LoggedIn
        {
            get
            {
                return _LoggedIn;
            }
            set
            {
                SetProperty(ref _LoggedIn, value);
            }
        }
        public string FavoriteBar { get; set; }
        public string FavoriteDrinks { get; set; }
    }
}
