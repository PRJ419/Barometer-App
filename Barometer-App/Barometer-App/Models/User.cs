using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Prism.Mvvm;

namespace Barometer_App.Models
{
    public class User : BindableBase
    {
        //Singleton pattern to ensure on only customer is logged in
        private static readonly User Customer = new User();
        private User() {}

        public static User GetCustomer()
        {
            return Customer;
        }

        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        //Deprecated begin
        public string Email{ get; set; }
        public string Password { get; set; }
        //Deprecated end
        private string _usertoken;
        public string UserToken
        {
            get => _usertoken;
            set
            {
                _usertoken = value;
                _loggedIn = (_usertoken != null);
                RaisePropertyChanged("LoggedIn");
            }
        }

        private bool _loggedIn;
        public bool LoggedIn
        {
            get { return _loggedIn; }
        }
        public string FavoriteBar { get; set; }
        public string FavoriteDrinks { get; set; }
    }
}
