using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BarOMeterApp.Unit.Test
{
    [TestFixture]
    class TestBar
    {
        public Barometer_App.Models.Bar Bar;
        [SetUp]
        public void setup()
        {
            Bar = new Barometer_App.Models.Bar();
        }

        [Test]
        public void SetBarName_NewBar_NameIsSet()
        {
            //Act
            Bar.BarName = "TestBar";

            //Assert
            Assert.That(Bar.BarName, Is.EqualTo("TestBar"));
        }

        [Test]
        public void SetBarAddress_NewBar_AddressIsSet()
        {
            //Act
            Bar.Address = "TestAddress";

            //Assert
            Assert.That(Bar.Address, Is.EqualTo("TestAddress"));
        }

        [Test]
        public void SetBarShortDescription_NewBar_ShortDescriptionIsSet()
        {
            //Act
            Bar.ShortDescription = "Very short description";

            //Assert
            Assert.That(Bar.ShortDescription, Is.EqualTo("Very short description"));
        }

        [Test]
        public void SetBarLongDescription_NewBar_LongDescriptionIsSet()
        {
            //Act
            Bar.LongDescription = "Very long description";

            //Assert
            Assert.That(Bar.LongDescription, Is.EqualTo("Very long description"));
        }

        [Test]
        public void SetBarCVR_NewBar_CVRIsSet()
        {
            //Act
            Bar.CVR = "1234567890";

            //Assert
            Assert.That(Bar.CVR, Is.EqualTo("1234567890"));
        }

        [Test]
        public void SetBarPhoneNumber_NewBar_PhoneNumberIsSet()
        {
            //Act
            Bar.PhoneNumber = "12345678";

            //Assert
            Assert.That(Bar.PhoneNumber, Is.EqualTo("12345678"));
        }

        [Test]
        public void SetBarEmail_NewBar_EmailIsSet()
        {
            //Act
            Bar.Email = "test@email.com";

            //Assert
            Assert.That(Bar.Email, Is.EqualTo("test@email.com"));
        }

        [Test]
        public void SetBarImage_NewBar_ImageIsSet()
        {
            //Act
            Bar.Image = "testdomain.com/image.jpg";

            //Assert
            Assert.That(Bar.Image, Is.EqualTo("testdomain.com/image.jpg"));
        }

        [Test]
        public void SetBarAvgRating_NewBar_AvgRatingIsSet()
        {
            //Act
            Bar.AvgRating = 5;

            //Assert
            Assert.That(Bar.AvgRating, Is.EqualTo(5));
        }

        [Test]
        public void SetBarAgeLimit_NewBar_AgeLimitIsSet()
        {
            //Act
            Bar.AgeLimit = 18;

            //Assert
            Assert.That(Bar.AgeLimit, Is.EqualTo(18));
        }

        [Test]
        public void SetBarEducations_NewBar_EducationIsSet()
        {
            //Act
            Bar.Educations = "Test Education";

            //Assert
            Assert.That(Bar.Educations, Is.EqualTo("Test Education"));
        }
    }
}
