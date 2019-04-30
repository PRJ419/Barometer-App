using System;
using System.Collections.Generic;
using System.Text;

namespace Barometer_App.Models
{
    /// <summary>
    /// Model representation of a Coupon of a bar
    /// </summary>
    public class Coupon
    {
        /// <summary>
        /// Name of the bar where the coupon is valid
        /// </summary>
        public string BarName { get; set; }
        /// <summary>
        /// ID of the coupon
        /// </summary>
        public string CouponID { get; set; }
        /// <summary>
        /// Expiration date of the coupon
        /// </summary>
        public DateTime ExpirationDate { get; set; }
    }
}