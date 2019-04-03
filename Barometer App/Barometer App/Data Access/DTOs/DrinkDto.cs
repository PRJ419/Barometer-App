using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RESTClient.DTOs
{
    /// <summary>
    /// Transfer object for drinks
    /// </summary>
    public class DrinkDto
    {
        [MaxLength(150)]
        public string BarName { get; set; }

        [MaxLength(50)]
        public string DrinksName { get; set; }

        public double Price { get; set; }
    }
}