using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Prism.Mvvm;

namespace Barometer_App.Models
{
    /// <summary>
    /// Singleton class representing the user in the application
    /// </summary>
    public class User : BindableBase
    {
        //Singleton pattern to ensure on only customer is logged in
        /// <summary>
        /// Static value to hold the singleton of the user information
        /// </summary>
        private static readonly User Customer = new User();

        /// <summary>
        /// Private constructor to stop more instances from being made
        /// </summary>
        private User() {}

        /// <summary>
        /// Accessor for the singleton instance of the User class
        /// </summary>
        /// <returns> Returns a handle for the singleton User </returns>
        public static User GetCustomer()
        {
            return Customer;
        }

        /// <summary>
        /// Public string for holding and accessing the UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Public string for holding and accessing the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Nullable Public DateTime for holding and accessing the Birthday of the User
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Private holder for the JWT of Identity when logged in
        /// </summary>
        private string _usertoken;

        /// <summary>
        /// Public setter and getter logic for the JWT
        /// </summary>
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

        /// <summary>
        /// Private boolean for holding the login status 
        /// </summary>
        private bool _loggedIn;

        /// <summary>
        /// Public getter method for the _loggedIn variable
        /// </summary>
        public bool LoggedIn
        {
            get { return _loggedIn; }
        }

        /// <summary>
        /// Private boolean for holding the BarRep status
        /// </summary>
        private bool _isBarRep;

        /// <summary>
        /// Public getter and setter for the _isBarRep variable
        /// </summary>
        public bool IsBarRep
        {
            get { return _isBarRep; }
            set { SetProperty(ref _isBarRep, value); }
        }

        /// <summary>
        /// Public string for holding the name of the Users favorite bar
        /// </summary>
        public string FavoriteBar { get; set; }

        /// <summary>
        /// Public string for holding the name of the Users favorite drink
        /// </summary>
        public string FavoriteDrinks { get; set; }
    }
}
