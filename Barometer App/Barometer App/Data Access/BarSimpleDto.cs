using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClient.DTOs
{
    
        /// <summary>
        /// Transfer object for the listview of bars
        /// </summary>
        public class BarSimpleDto
        {
            // Is the class representation simple
            public bool isSimple { get; private set; }
           

            // Max length 150
            private string _BarName { get; set; }
            public string BarName
            {
                get { return _BarName; }
                 set
                {
                    if (value.Length <= 150)
                        _BarName = value;
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            }

            // Rating from 0.0 to 5.0
            private double _AvgRating { get; set; }

            public double AvgRating
            {
                get { return _AvgRating; }
                set
                {
                    if (value >= 0.0 && value <= 5.0)
                        _AvgRating = value;
                    else
                        throw new ArgumentOutOfRangeException();
                }
            }

            // max length 500
            private string _ShortDescription;

            public string ShortDescription
            {
                get { return _ShortDescription; }
                set
                {
                    if (value.Length <= 500)
                        _ShortDescription = value;
                    else
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    
}
