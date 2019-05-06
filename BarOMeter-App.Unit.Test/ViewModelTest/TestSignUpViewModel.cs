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
    class TestSignUpViewModel
    {
        private IRestClient RestClient;
        private IAlerter Alerter;
        private INavigationService NavService;
        private User user;
        private SignupViewModel uut;

        [SetUp]
        public void setup()
        {
            RestClient = Substitute.For<IRestClient>();
            Alerter = Substitute.For<IAlerter>();
            NavService = Substitute.For<INavigationService>();
            uut = new SignupViewModel(NavService, RestClient, Alerter);
        }

        [Test]
        public void SignUpIsCalled_PasswordMismatch_AlerterIsCalled()
        {
            //Arrange
            uut.password = "Pass123";
            uut.confpass = "Pass1";

            //Act
            uut.SignupCommand.Execute(null);

            //Assert
            Alerter.Received(1).Alert("Error", Arg.Is<string>(str => str.Contains("match")), Arg.Any<string>());
        }

        [Test]
        public void SignUpIsCalled_RestCallSucceeds_AlerterIsCalled()
        {
            //Arrange
            uut.password = "Pass123";
            uut.confpass = "Pass123";

            RestClient.RegisterAsync(null).ReturnsForAnyArgs(true);

            //Act
            uut.SignupCommand.Execute(null);

            //Assert
            Alerter.Received(1).Alert("Notice", Arg.Is<string>(str => str.Contains("registered")), Arg.Any<string>());
        }

        [Test]
        public void SignUpIsCalled_RestCallSucceeds_NavServiceIsCalled()
        {
            //Arrange
            uut.password = "Pass123";
            uut.confpass = "Pass123";

            RestClient.RegisterAsync(null).ReturnsForAnyArgs(true);

            //Act
            uut.SignupCommand.Execute(null);

            //Assert
            NavService.Received().GoBackAsync();
        }

        [Test]
        public void SignUpIsCalled_RestCallFails_AlerterIsCalled()
        {
            //Arrange
            uut.password = "Pass123";
            uut.confpass = "Pass123";

            RestClient.RegisterAsync(null).ReturnsForAnyArgs(false);

            //Act
            uut.SignupCommand.Execute(null);

            //Assert
            Alerter.ReceivedWithAnyArgs()
                .Alert("Error", Arg.Is<string>(str => str.Contains("went wrong")), Arg.Any<string>());
        }

        [Test]
        public void SignUpIsCalled_RestCallThrowsException_AlerterIsCalled()
        {
            //Arrange
            uut.password = "Pass123";
            uut.confpass = "Pass123";

            RestClient.RegisterAsync(null).ThrowsForAnyArgs(new Exception("Something bad happened, woops"));

            //Act
            uut.SignupCommand.Execute(null);

            //Assert
            Alerter.ReceivedWithAnyArgs()
                .Alert("Error", Arg.Is<string>(str => str.Contains("bad happened")), Arg.Any<string>());
        }
    }
}
