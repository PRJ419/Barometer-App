using System.Collections.ObjectModel;
using Barometer_App.Models;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    public class DetailedBarEditViewModel : ViewModelBase
    {
        private Bar _bar;

        public Bar Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }

        public DetailedBarEditViewModel()
        {
            Bar = new Bar();
            Title = "Detailed Bar Editing Page";
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            Bar = await RestClient.GetDetailedBar("Barname");
        }
    }
}