using System;
using System.Collections.Generic;
using System.Text;

namespace Barometer_App.Models
{
    public class Coupon
    {
        public string BarName { get; set; }
        public string CouponID { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
