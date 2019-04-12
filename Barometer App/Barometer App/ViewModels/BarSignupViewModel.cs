using System.Windows.Input;
using Barometer_App.Models;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    public class BarSignupViewModel : ViewModelBase
    {

        private Bar _bar;

        public Bar Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }

        private readonly INavigationService _nav;
        private readonly IRestClient _restClient;

        public BarSignupViewModel(INavigationService navigationService)
        {
            _nav = navigationService;
            Bar = new Bar();
            _restClient = new RestClient();
            Title = "Bar Sign Up";
        }

        private ICommand _signUpCommand;

        public ICommand SignUpCommand => _signUpCommand ?? (_signUpCommand = new DelegateCommand(OnSignUp));

        private async void OnSignUp()
        {
           await _restClient.CreateBar(Bar);
        }

    }
}