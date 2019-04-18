using System;
using System.Windows.Input;
using Barometer_App.DTO;
using Barometer_App.Services;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    public class SignupViewModel : ViewModelBase
    {
        public string name { get; set; }
        public string email { get; set; }
        public DateTime birthday { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confpass { get; set; }

        public InputValidator validator;

        private RestClient _apiService = new RestClient();
  
        public INavigationService _navigationService { get; }
        public SignupViewModel(INavigationService navigationService) : base()
        {
            Title = "Sign Up";
            _navigationService = navigationService;
            validator = new InputValidator();
        }

        #region Commands

        private ICommand _navigateToBarSignUpCommand;

        public ICommand NavigateToBarSignUpCommand =>
            _navigateToBarSignUpCommand ?? (_navigateToBarSignUpCommand = new DelegateCommand(OnNavigateToBarSignUp));

        public async void OnNavigateToBarSignUp()
        {
            await _navigationService.NavigateAsync("BarSignup");
        }

        private ICommand _signupCommand;

        public ICommand SignupCommand => _signupCommand ?? (_signupCommand = new DelegateCommand(OnSignupCommand));

        public async void OnSignupCommand()
        {
            RegisterDTO dto = new RegisterDTO()
            {
                Email = email,
                Username = username,
                Password = password,
            };

        if(await _apiService.RegisterAsync(dto))
            await _navigationService.GoBackAsync();
        else
            await App.Current.MainPage.DisplayAlert("Error", "Something went wrong in the registration!", "OK");
            
        }

        #endregion
    }
}