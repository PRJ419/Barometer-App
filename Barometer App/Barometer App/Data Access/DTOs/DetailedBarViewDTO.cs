using System;
using Prism.Mvvm;

namespace RESTClient.DTOs
{
    public class DetailedBarViewDTO : BindableBase
    {
        // Is the class representation simple
        public bool isSimple { get; private set; }


        // Max length 150
        private string _barName;
        public string BarName
        {
            get => _barName;
            set
            {
                if (value.Length <= 150)
                    SetProperty(ref _barName, value);
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        // Rating from 0.0 to 5.0
        private double _avgRating;

        public double AvgRating
        {
            get => _avgRating;
            set
            {
                if (value >= 0.0 && value <= 5.0)
                    SetProperty(ref _avgRating, value);
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        // max length 500
        private string _longDescription;

        public string LongDescription
        {
            get => _longDescription;
            set
            {
                if (value.Length <= 500)
                    SetProperty(ref _longDescription, value);
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        private string _image;

        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        private string _address;

        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        private int _ageRestriction;

        public int AgeRestriction
        {
            get => _ageRestriction;
            set => SetProperty(ref _ageRestriction, value);
        }
    }
}
