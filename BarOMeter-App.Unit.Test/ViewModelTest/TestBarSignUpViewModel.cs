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
    class TestBarSignUpViewModel
    {
        private IRestClient RestClient;
        private IAlerter Alerter;
        private INavigationService NavService;
        private BarSignupViewModel uut;

        [SetUp]
        public void setup()
        {
            RestClient = Substitute.For<IRestClient>();
            Alerter = Substitute.For<IAlerter>();
            NavService = Substitute.For<INavigationService>();
            uut = new BarSignupViewModel(NavService, RestClient, Alerter);
        }

        [Test]
        public void OnSignUp_PasswordMismatch_AlertIsCalled()
        {
            //Arrange
            uut.Bar.Password = "TestPass123";
            uut.ConfirmPassword = "TestPass1";

            //Act
            uut.SignUpCommand.Execute(null);

            //Assert
            Alerter.Received(1).Alert("Error", Arg.Is<string>(str => str.Contains("Passwords")), Arg.Any<string>());
        }

        [Test]
        public void OnSignUp_CallSucceeds_AlertIsCalled()
        {
            //Arrange
            uut.Bar.Password = "TestPass123";
            uut.ConfirmPassword = "TestPass123";

            RestClient.CreateBar(null).ReturnsForAnyArgs(true);

            //Act
            uut.SignUpCommand.Execute(null);

            //Assert
            Alerter.Received(1).Alert("Notice", Arg.Is<string>(str => str.Contains("registered")), Arg.Any<string>());
        }

        [Test]
        public void OnSignUp_CallSucceeds_NavigationIsCalled()
        {
            //Arrange
            uut.Bar.Password = "TestPass123";
            uut.ConfirmPassword = "TestPass123";

            RestClient.CreateBar(null).ReturnsForAnyArgs(true);

            //Act
            uut.SignUpCommand.Execute(null);

            //Assert
            NavService.Received(1).GoBackAsync();
        }

        [Test]
        public void OnSignUp_CallFails_AlertIsCalled()
        {
            //Arrange
            uut.Bar.Password = "TestPass123";
            uut.ConfirmPassword = "TestPass123";

            RestClient.CreateBar(null).ReturnsForAnyArgs(false);

            //Act
            uut.SignUpCommand.Execute(null);

            //Assert
            Alerter.Received(1).Alert("Error", Arg.Is<string>(str => str.Contains("Something")), Arg.Any<string>());
        }

        [Test]
        public void OnSignUp_CallFails_AlertIsCalledFromException()
        {
            //Arrange
            uut.Bar.Password = "TestPass123";
            uut.ConfirmPassword = "TestPass123";

            RestClient.CreateBar(null).ThrowsForAnyArgs(new DuplicateNameException("Bar or BarRep already exists"));

            //Act
            uut.SignUpCommand.Execute(null);

            //Assert
            Alerter.Received(1).Alert("Error", Arg.Is<string>(str => str.Contains("already exists")),
                Arg.Any<string>());
        }
    }
}
