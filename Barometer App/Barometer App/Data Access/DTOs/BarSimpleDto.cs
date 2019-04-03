using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RESTClient.DTOs
{
    /// <summary>
    /// Transfer object for the listview of bars
    /// </summary>
    public class BarSimpleDto
    {
        [Required]
        public string BarName { get; set; }

        [Range(0.0, 5.0)]
        public double AvgRating { get; set; }

        [MaxLength(500)]
        public string ShortDescription { get; set; }
    }
}
