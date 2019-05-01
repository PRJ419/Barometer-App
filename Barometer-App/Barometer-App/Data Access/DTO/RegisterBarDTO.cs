using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Barometer_App.DTO
{
    public class RegisterBarDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public string Name { get; set; }

        public string BarName { get; set; }
        public string Address { get; set; }
        public int AgeLimit { get; set; }
        public string Educations { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int CVR { get; set; }
        public int PhoneNumber { get; set; }
        public double AvgRating { get; set; }
        public string Image { get; set; }
    }
}
