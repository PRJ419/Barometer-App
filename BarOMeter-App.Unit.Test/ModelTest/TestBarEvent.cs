using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BarOMeterApp.Unit.Test
{
    [TestFixture]
    class TestBarEvent
    {
        public Barometer_App.Models.BarEvent BarEvent;
        [SetUp]
        public void setup()
        {
            BarEvent = new Barometer_App.Models.BarEvent();
        }

        [Test]
        public void SetBarEventBarName_NewBarEvent_BarNameIsSet()
        {
            //Act
            BarEvent.BarName = "TestBar";

            //Assert
            Assert.That(BarEvent.BarName, Is.EqualTo("TestBar"));
        }

        [Test]
        public void SetBarEventEventName_NewBarEvent_EventNameIsSet()
        {
            //Act
            BarEvent.EventName = "TestBar Event";

            //Assert
            Assert.That(BarEvent.EventName, Is.EqualTo("TestBar Event"));
        }

        [Test]
        public void SetBarEventDate_NewBarEvent_DateIsSet()
        {
            //Act
            BarEvent.Date = new DateTime(2019, 04, 29);

            //Assert
            Assert.That(BarEvent.Date, Is.EqualTo(new DateTime(2019, 04, 29)));
        }

        [Test]
        public void SetBarEventImage_NewBarEvent_ImageIsSet()
        {
            //Act
            BarEvent.Image = "testdomain.com/image.jpg";

            //Assert
            Assert.That(BarEvent.Image, Is.EqualTo("testdomain.com/image.jpg"));
        }
    }
}
