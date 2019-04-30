using System;
using System.Collections.Generic;
using System.Text;
using Barometer_App.Models;
using NUnit.Framework;

/*
 * Be careful about Singleton tests as the Singleton persists between tests
 */

namespace BarOMeterApp.Unit.Test
{
    [TestFixture]
    class TestUser
    {
        public Barometer_App.Models.User User; 
        [SetUp]
        public void setup()
        {
            User = User.GetCustomer();

            //Clear the singleton values between tests
            User.Name = null;
            User.Email = null;
            User.DateOfBirth = null;
            User.FavoriteBar = null;
            User.FavoriteDrinks = null;
            User.Password = null;
            User.UserName = null;
            User.UserToken = null;
        }

        [Test]
        public void SingletonGetter_SingletonAlreadyMade_SingletonsIsItself()
        {
            //Assert
            Assert.That(User, Is.EqualTo(User.GetCustomer()));
        }

        [Test]
        public void SetUserName_SingletonAlreadyMade_NameIsSet()
        {
            //Act
            User.Name = "TestName";

            //Assert
            Assert.That(User.Name, Is.EqualTo("TestName"));
        }

        [Test]
        public void SetUserUserName_SingletonAlreadyMade_UserNameIsSet()
        {
            //Act
            User.UserName = "Username";

            //Assert
            Assert.That(User.UserName, Is.EqualTo("Username"));
        }

        [Test]
        public void SetUserDateOfBirth_SingletonAlreadyMade_DateOfBirthIsSet()
        {
            //Act
            User.DateOfBirth = new DateTime(2019, 04, 29);

            //Assert
            Assert.That(User.DateOfBirth, Is.EqualTo(new DateTime(2019, 04, 29)));
        }

        [Test]
        public void SetUserUserToken_SingletonAlreadyMade_UserTokenIsSet()
        {
            //Act
            User.UserToken = "TestToken";

            //Assert
            Assert.That(User.UserToken, Is.EqualTo("TestToken"));
        }

        [Test]
        public void SetUserUserToken_SingletonAlreadyMade_LoggedInIsTrue()
        {
            //Act
            User.UserToken = "TestToken";

            //Assert
            Assert.That(User.LoggedIn, Is.True);
        }

        [Test]
        public void SetUserUserTokenToNull_SingletonAlreadyMade_LoggedInIsFalse()
        {
            //Act
            User.UserToken = null;

            //Assert
            Assert.That(User.LoggedIn, Is.False);
        }

        [Test]
        public void SetUserFavoriteBar_SingletonAlreadyMade_FavoriteBarIsSet()
        {
            //Act
            User.FavoriteBar = "Favorite Bar";

            //Assert
            Assert.That(User.FavoriteBar, Is.EqualTo("Favorite Bar"));
        }

        [Test]
        public void SetUserFavoriteDrinks_SingletonAlreadyMade_FavoriteDrinksIsSet()
        {
            //Act
            User.FavoriteDrinks = "Favorite Drink1, Favorite Drink2";

            //Assert
            Assert.That(User.FavoriteDrinks, Is.EqualTo("Favorite Drink1, Favorite Drink2"));
        }
    }
}
