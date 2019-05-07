using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Barometer_App.DTO
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string FavoriteBar { get; set; }
        public string FavoriteDrink { get; set; }
    }
}
