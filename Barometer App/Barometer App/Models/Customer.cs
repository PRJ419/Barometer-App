using System;
using System.Collections.Generic;
using System.Text;

namespace Barometer_App.Models
{
    public class Customer
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public string Password { get; set; }
        public string FavoriteBar { get; set; }
        public string FavoriteDrinks { get; set; }
    }
}
