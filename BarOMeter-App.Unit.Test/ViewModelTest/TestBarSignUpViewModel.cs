using System;
using System.Collections.Generic;
using System.Text;
using Barometer_App.Models;
using Barometer_App.ViewModels;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Prism.Navigation;
using RESTClient;

namespace BarOMeterApp.Unit.Test
{
    [TestFixture]
    class TestBarSignUpViewModel
    {
        [SetUp]
        public void setup()
        {
            var RestClient = Substitute.For<IRestClient>();
            var Alerter = Substitute.For<IAlerter>();
            var uut = new BarSignupViewModel(Substitute.For<INavigationService>(), RestClient, Alerter);
        }

        //public void OnSignUp_
    }
}
