using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Mvvm;

namespace Barometer_App.Models
{
    public class Bar : BindableBase
    {
        //Properties for a bar
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _address;

        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        private string _postalCode;

        public string PostalCode
        {
            get => _postalCode;
            set => SetProperty(ref _postalCode, value);
        }

        private string _aboutText;
        public string AboutText
        {
            get => _aboutText;
            set => SetProperty(ref _aboutText, value);
        }

        private string _cvr;
        public string CVR {
            get => _cvr;
            set => SetProperty(ref _cvr, value);
        }

        private string _phoneNumber;
        public string PhoneNumber {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        private string _email;
        public string Email {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private int _barId;
        public int BarId {
            get => _barId;
            set => SetProperty(ref _barId, value);
        }

        private string _image;
        public string Image {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        private int _rating;
        public int Rating {
            get => _rating;
            set => SetProperty(ref _rating, value);
        }
    }
}