using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barometer_App.ViewModels;
using NSubstitute;
using NUnit.Framework;
using Prism.Navigation;

namespace BarometerApp.Test.Unit
{
    public class TestBarEditViewModel
    {
        [SetUp]
        public void Setup()
        {
           
            
        }

        [Test]
        public void ShouldNotifyListenersWhenBarNameIsNotChanged()
        {
            var viewModel = new BarEditViewModel(Substitute.For<INavigationService>());
            var propertiesChanged = new List<string>();

            viewModel.Bar.BarName = "Test";
            viewModel.PropertyChanged += (s, e) => propertiesChanged.Add(e.PropertyName);

            viewModel.Bar.BarName = "Test";

            Assert.AreEqual(0, propertiesChanged.Count);
        }

        [Test]
        public void ShouldNotifyListenersWhenBarNameChanges()
        {
            var viewModel = new BarEditViewModel(Substitute.For<INavigationService>());
            var waschanged = false;

            viewModel.Bar.BarName = "Test";
            viewModel.PropertyChanged += (s, e) => waschanged = true;
            //Why is this zero?
            viewModel.Bar.BarName = "Something";

            Assert.IsTrue(waschanged);
        }
    }
}
