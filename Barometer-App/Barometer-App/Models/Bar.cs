using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Mvvm;

namespace Barometer_App.Models
{
    /// <summary>
    /// Model representation for the Bar
    /// </summary>
    public class Bar : BindableBase
    {
        /// <summary>
        /// Private string for holding the name of the bar
        /// </summary>
        private string _barName;

        /// <summary>
        /// Bindable property for accessing the _barName private
        /// </summary>
        public string BarName
        {
            get => _barName;
            set => SetProperty(ref _barName, value);
        }

        /// <summary>
        /// Private string for holding the address of the bar
        /// </summary>
        private string _address;

        /// <summary>
        /// Bindable property for accessing the _address private
        /// </summary>
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        /// <summary>
        /// Private string for holding the short description of the bar
        /// </summary>
        private string _shortDescription;

        /// <summary>
        /// Bindable property for accessing the _shortDescription private
        /// </summary>
        public string ShortDescription
        {
            get => _shortDescription;
            set => SetProperty(ref _shortDescription, value);
        }

        /// <summary>
        /// Private string for holding the long version description of the bar
        /// </summary>
        private string _longDescription;

        /// <summary>
        /// Bindable property for accessing the _longDescription private
        /// </summary>
        public string LongDescription
        {
            get => _longDescription;
            set => SetProperty(ref _longDescription, value);
        }

        /// <summary>
        /// Private string for holding the CVR number of the bar
        /// </summary>
        private string _cvr;

        /// <summary>
        /// Bindable property for accessing the _cvr private
        /// </summary>
        public string CVR
        {
            get => _cvr;
            set => SetProperty(ref _cvr, value);
        }

        /// <summary>
        /// Private string for holding the phone number of the bar
        /// </summary>
        private string _phoneNumber;

        /// <summary>
        /// Bindable property for accessing the _phoneNumber private
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        /// <summary>
        /// Private string for holding the email of the bar
        /// </summary>
        private string _email;

        /// <summary>
        /// Bindable property for accessing the _email private
        /// </summary>
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        /// <summary>
        /// Private string for holding the URI of the image of the bar
        /// </summary>
        private string _image;

        /// <summary>
        /// Bindable property for accessing the _image private
        /// </summary>
        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        /// <summary>
        /// Private double for holding the average rating of the bar
        /// </summary>
        private double _avgRating;

        /// <summary>
        /// Bindable property for accessing the _avgRating private
        /// </summary>
        public double AvgRating
        {
            get => _avgRating;
            set => SetProperty(ref _avgRating, value);
        }

        /// <summary>
        /// Private integer for holding the age limit of the bar
        /// </summary>
        private int _ageLimit;

        /// <summary>
        /// Bindable property for accessing the _ageLimit private
        /// </summary>
        public int AgeLimit
        {
            get => _ageLimit;
            set => SetProperty(ref _ageLimit, value);
        }

        /// <summary>
        /// Private string for holding the educations associated to the bar
        /// </summary>
        private string _educations;

        /// <summary>
        /// Bindable property for accessing the _educations private
        /// </summary>
        public string Educations
        {
            get => _educations;
            set => SetProperty(ref _educations, value);

           // Der skal implementeres drinks , Event list, Coupons mm hvis vi når så langt. 
        }
    }
}