using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BarOMeterApp.Unit.Test
{
    [TestFixture]
    class TestCoupon
    {
        public Barometer_App.Models.Coupon Coupon;
        [SetUp]
        public void setup()
        {
            Coupon = new Barometer_App.Models.Coupon();
        }

        [Test]
        public void SetCouponBarName_NewCoupon_BarNameIsSet()
        {
            //Act
            Coupon.BarName = "TestBar";

            //Assert
            Assert.That(Coupon.BarName, Is.EqualTo("TestBar"));
        }

        [Test]
        public void SetCouponCouponID_NewCoupon_CouponIDIsSet()
        {
            //Act
            Coupon.CouponID = "TestCouponID";

            //Assert
            Assert.That(Coupon.CouponID, Is.EqualTo("TestCouponID"));
        }

        [Test]
        public void SetCouponExpirationDate_NewCoupon_ExpirationDateIsSet()
        {
            //Act
            Coupon.ExpirationDate = new DateTime(2019, 04, 29);

            //Assert
            Assert.That(Coupon.ExpirationDate, Is.EqualTo(new DateTime(2019, 04, 29)));
        }
    }
}
