using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace RESTClient.DTOs
{
    
        /// <inheritdoc />
        /// <summary>
        /// Transfer object for the listview of bars
        /// </summary>
        public class BarListViewDto : BindableBase
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
            private string _shortDescription;

            public string ShortDescription
            {
                get => _shortDescription;
                set
                {
                    if (value.Length <= 500)
                        SetProperty(ref _shortDescription, value);
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

            private string _postalCode;

            public string PostalCode
            {
                get => _postalCode;
                set
                {
                    if (value.Length <= 10000)
                        SetProperty(ref _postalCode, value);
                    else
                        throw new ArgumentOutOfRangeException();
                }
            }
    }
    
}
