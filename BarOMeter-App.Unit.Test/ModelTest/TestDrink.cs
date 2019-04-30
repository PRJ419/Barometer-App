using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BarOMeterApp.Unit.Test
{
    [TestFixture]
    class TestDrink
    {
        public Barometer_App.Models.Drink Drink;
        [SetUp]
        public void setup()
        {
            Drink = new Barometer_App.Models.Drink();
        }

        [Test]
        public void SetDrinkBarName_NewDrink_BarNameIsSet()
        {
            //Act
            Drink.BarName = "TestBar";

            //Assert
            Assert.That(Drink.BarName, Is.EqualTo("TestBar"));
        }

        [Test]
        public void SetDrinkDrinkName_NewDrink_DrinkNameIsSet()
        {
            //Act
            Drink.DrinksName = "Test Drink";

            //Assert
            Assert.That(Drink.DrinksName, Is.EqualTo("Test Drink"));
        }

        [Test]
        public void SetDrinkPrice_NewDrink_PriceIsSet()
        {
            //Act
            Drink.Price = 10.0;

            //Assert
            Assert.That(Drink.Price, Is.EqualTo(10.0));
        }

        [Test]
        public void SetDrinkImage_NewDrink_ImageIsSet()
        {
            //Act
            Drink.Image = "testdomain.com/image.jpg";

            //Assert
            Assert.That(Drink.Image, Is.EqualTo("testdomain.com/image.jpg"));
        }
    }
}
