using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BarOMeterApp.Unit.Test
{
    [TestFixture]
    class TestBarSimple
    {
        public Barometer_App.Models.BarSimple BarSimple;
        [SetUp]
        public void setup()
        {
            BarSimple = new Barometer_App.Models.BarSimple();
        }

        [Test]
        public void SetBarName_NewBar_NameIsSet()
        {
            //Act
            BarSimple.BarName = "TestBar";

            //Assert
            Assert.That(BarSimple.BarName, Is.EqualTo("TestBar"));
        }

        [Test]
        public void SetBarShortDescription_NewBar_ShortDescriptionIsSet()
        {
            //Act
            BarSimple.ShortDescription = "Very short description";

            //Assert
            Assert.That(BarSimple.ShortDescription, Is.EqualTo("Very short description"));
        }

        [Test]
        public void SetBarImage_NewBar_ImageIsSet()
        {
            //Act
            BarSimple.Image = "testdomain.com/image.jpg";

            //Assert
            Assert.That(BarSimple.Image, Is.EqualTo("testdomain.com/image.jpg"));
        }

        [Test]
        public void SetBarAvgRating_NewBar_AvgRatingIsSet()
        {
            //Act
            BarSimple.AvgRating = 5;

            //Assert
            Assert.That(BarSimple.AvgRating, Is.EqualTo(5));
        }
    }
}
