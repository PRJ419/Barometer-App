using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Mvvm;

namespace Barometer_App.Models
{
    public class Bar : BindableBase
    {
        //Properties for a bar
        private string _barName;

        public string BarName
        {
            get => _barName;
            set => SetProperty(ref _barName, value);
        }

        private string _address;

        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        private string _shortDescription;

        public string ShortDescription
        {
            get => _shortDescription;
            set => SetProperty(ref _shortDescription, value);
        }

        private string _longDescription;

        public string LongDescription
        {
            get => _longDescription;
            set => SetProperty(ref _longDescription, value);
        }

        private string _cvr;

        public string CVR
        {
            get => _cvr;
            set => SetProperty(ref _cvr, value);
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        private string _email;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _image;

        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        private double _avgRating;

        public double AvgRating
        {
            get => _avgRating;
            set => SetProperty(ref _avgRating, value/5);
        }

        private int _ageLimit;

        public int AgeLimit
        {
            get => _ageLimit;
            set => SetProperty(ref _ageLimit, value);
        }

        private int _educations;

        public int Educations
        {
            get => _educations;
            set => SetProperty(ref _educations, value);

            //Der skal implementeres drinks , Event list, Coupons mm hvis vi når så langt. 
        }
    }
}