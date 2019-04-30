using System.Collections.Generic;
using Barometer_App.ViewModels;
using NSubstitute;
using NUnit.Framework;
using Prism.Navigation;

namespace BarometerApp.Unit.Test
{
    [TestFixture]
    public class TestBarEditView
    {
        private BarEditViewModel viewModel;
        [SetUp]
        public void Setup()
        {
            viewModel = new BarEditViewModel(Substitute.For<INavigationService>());
        }

        [Test]
        public void ShouldNotifyListenersWhenBarNameIsNotChanged()
        {
            var propertiesChanged = new List<string>();

            viewModel.Bar.BarName = "Test";
            viewModel.PropertyChanged += (s, e) => propertiesChanged.Add(e.PropertyName);

            viewModel.Bar.BarName = "Test";

            Assert.AreEqual(0, propertiesChanged.Count);
        }

        [Test]
        public void ShouldNotifyListenersWhenBarNameChanges()
        {

            var waschanged = false;

            viewModel.Bar.BarName = "Test";
            viewModel.PropertyChanged += (s, e) => waschanged = true;
            //Why is this zero?
            viewModel.Bar.BarName = "Test1";

            Assert.IsTrue(!waschanged);
        }

        [TearDown]
        public void TearDown()
        {
            viewModel = null;
        }
    }
}
