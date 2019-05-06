using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Barometer_App.Models;
using Barometer_App.ViewModels;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Prism.Navigation;
using RESTClient;

namespace BarOMeterApp.Unit.Test
{
    [TestFixture]
    class TestLoginViewModel
    {
        private IRestClient RestClient;
        private IAlerter Alerter;
        private INavigationService NavService;
        private User user;
        private LoginViewModel uut;

        [SetUp]
        public void setup()
        {
            user = User.GetCustomer();

            //Clear the singleton values between tests
            user.Name = null;
            user.DateOfBirth = null;
            user.FavoriteBar = null;
            user.FavoriteDrinks = null;
            user.UserName = null;
            user.UserToken = null;

            RestClient = Substitute.For<IRestClient>();
            Alerter = Substitute.For<IAlerter>();
            NavService = Substitute.For<INavigationService>();
            uut = new LoginViewModel(NavService, RestClient, Alerter);
        }

        [Test]
        public void LoginIsCalled_AlreadyLoggedIn_DoesNothing()
        {
            //Arrange
            user.UserToken = "Token";

            //Act
            uut.LoginCommand.Execute(null);

            //Assert
            Alerter.DidNotReceiveWithAnyArgs().Alert(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
            NavService.DidNotReceiveWithAnyArgs().GoBackAsync();
            RestClient.DidNotReceiveWithAnyArgs().LoginAsync(null);
        }

        [Test]
        public void LoginIsCalled_NotLoggedIn_TokenIsSet()
        {
            //Arrange
            uut.Username = "User";
            uut.Password = "Pass";

            RestClient.LoginAsync(null).ReturnsForAnyArgs("Token");

            //Act
            uut.LoginCommand.Execute(null);

            //Assert
            Assert.That(user.UserToken, Is.EqualTo("Token"));
        }

        [Test]
        public void LoginIsCalled_NotLoggedIn_NavIsCalled()
        {
            //Arrange
            uut.Username = "User";
            uut.Password = "Pass";

            RestClient.LoginAsync(null).ReturnsForAnyArgs("Token");
            RestClient.GetSpecificBarRepresentative(null).ReturnsForAnyArgs(new BarRepresentative());

            //Act
            uut.LoginCommand.Execute(null);

            //Assert
            NavService.Received(1).GoBackAsync();
        }

        [Test]
        public void LoginIsCalled_InformationIsFromBarRep_BarRepIsLoggedIn()
        {
            //Arrange
            uut.Username = "User";
            uut.Password = "Pass";

            RestClient.LoginAsync(null).ReturnsForAnyArgs("Token");
            RestClient.GetSpecificBarRepresentative(null).ReturnsForAnyArgs(new BarRepresentative() { BarName = "TestBar", Name = "NameOfPerson", Username = "BarUserName" });

            //Act
            uut.LoginCommand.Execute(null);

            //Assert
            Assert.That(user.IsBarRep, Is.True);
        }

        [Test]
        public void LoginIsCalled_InformationIsFromBarRep_NavIsCalled()
        {
            //Arrange
            uut.Username = "User";
            uut.Password = "Pass";

            RestClient.LoginAsync(null).ReturnsForAnyArgs("Token");
            RestClient.GetSpecificBarRepresentative(null).ReturnsForAnyArgs(new BarRepresentative() {BarName = "TestBar", Name = "NameOfPerson", Username = "BarUserName"});

            //Act
            uut.LoginCommand.Execute(null);

            //Assert
            NavService.Received(1).GoBackAsync();
        }

        [Test]
        public void LoginIsCalled_LoginAsyncFails_AlerterIsCalled()
        {
            //Arrange
            uut.Username = "User";
            uut.Password = "Pass";

            string result = null;
            RestClient.LoginAsync(null).ReturnsForAnyArgs(result);
            RestClient.GetSpecificBarRepresentative(null).ReturnsForAnyArgs(new BarRepresentative() { BarName = "TestBar", Name = "NameOfPerson", Username = "BarUserName" });

            //Act
            uut.LoginCommand.Execute(null);

            //Assert
            NavService.DidNotReceive().GoBackAsync();
            Alerter.Received(1).Alert("Error", Arg.Is<string>(str => str.Contains("went wrong")), Arg.Any<string>());
        }

        [Test]
        public void LoginIsCalled_LoginAsyncThrowsException_AlerterIsCalledCorrectly()
        {
            //Arrange
            uut.Username = "User";
            uut.Password = "Pass";

            string result = null;
            RestClient.LoginAsync(null).ThrowsForAnyArgs(new Exception("Something bad happened, woops"));
            RestClient.GetSpecificBarRepresentative(null).ReturnsForAnyArgs(new BarRepresentative() { BarName = "TestBar", Name = "NameOfPerson", Username = "BarUserName" });

            //Act
            uut.LoginCommand.Execute(null);

            //Assert
            NavService.DidNotReceive().GoBackAsync();
            Alerter.Received(1).Alert("Error", Arg.Is<string>(str => str.Contains("bad happened")), Arg.Any<string>());
        }
    }
}
