using Barometer_App.Models;
using Barometer_App.ViewModels;
using Prism.Navigation;

namespace Barometer_App.ViewModels
{
    public class BarRatingViewModel : ViewModelBase
    {


        public BarRatingViewModel(INavigationService navigationService) : base()
        {
            Bar = new Bar();
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            var bar = parameters.GetValue<Bar>("Bar");
            Bar = bar;
        }

        private Bar _bar;
        public Bar Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }
    }
}