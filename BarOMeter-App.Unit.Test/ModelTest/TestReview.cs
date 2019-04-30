using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BarOMeterApp.Unit.Test
{
    [TestFixture]
    class TestReview
    {
        public Barometer_App.Models.Review Review;
        [SetUp]
        public void setup()
        {
            Review = new Barometer_App.Models.Review();
        }

        [Test]
        public void SetReviewBarPressure_NewReview_BarPressureIsSet()
        {
            //Act
            Review.BarPressure = 5;

            //Assert
            Assert.That(Review.BarPressure, Is.EqualTo(5));
        }

        [Test]
        public void SetReviewBarName_NewReview_BarNameIsSet()
        {
            //Act
            Review.BarName = "TestBar";

            //Assert
            Assert.That(Review.BarName, Is.EqualTo("TestBar"));
        }

        [Test]
        public void SetReviewUsername_NewReview_UsernameIsSet()
        {
            //Act
            Review.Username = "TestUser";

            //Assert
            Assert.That(Review.Username, Is.EqualTo("TestUser"));
        }
    }
}
