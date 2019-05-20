using System;
using System.Windows.Input;
using Barometer_App.DTO;
using Barometer_App.Models;
using Prism;
using Prism.Commands;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    /// <summary>
    /// ViewModel for the Signup View
    /// </summary>
    public class SignupViewModel : ViewModelBase
    {
        /// <summary>
        /// Alerter used for popups
        /// </summary>
        private IAlerter Alerter;
        /// <summary>
        /// String property for View to bind to
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// String property for View to bind to
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// DateTime property for View to bind to
        /// </summary>
        public DateTime birthday { get; set; }

        /// <summary>
        /// String property for View to bind to
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// String property for View to bind to
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// String property for View to bind to
        /// </summary>
        public string confpass { get; set; }

        /// <summary>
        /// Navigation Service provided by Prism, which is later used for navigation to other Views and popping back to earlier Views when logged in.
        /// </summary>
        public INavigationService _navigationService { get; }

        /// <summary>
        /// Constructor for the ViewModel for the Signup View
        /// This sets the Title and constructs an InputValidator for use in checking inputs
        /// </summary>
        /// <param name="navigationService"></param>
        public SignupViewModel(INavigationService navigationService)
        {
            Title = "Sign Up";
            _navigationService = navigationService;
            birthday = DateTime.Now;
            Alerter = new Alerter();
        }

        public SignupViewModel(INavigationService navigationService, IRestClient restClient, IAlerter alert) : base(restClient)
        {
            Title = "Sign Up";
            _navigationService = navigationService;
            birthday = DateTime.Now;

            Alerter = alert;
        }

        #region Commands

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _navigateToBarSignUpCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand NavigateToBarSignUpCommand =>
            _navigateToBarSignUpCommand ?? (_navigateToBarSignUpCommand = new DelegateCommand(OnNavigateToBarSignUp));

        /// <summary>
        /// Logic that defines behaviour for the BarSignup navigation
        /// </summary>
        private async void OnNavigateToBarSignUp()
        {
            await _navigationService.NavigateAsync("BarSignup");
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _signupCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand SignupCommand => _signupCommand ?? (_signupCommand = new DelegateCommand(OnSignupCommand));

        /// <summary>
        /// Logic that defines behaviour for the Signup action
        /// </summary>
        private async void OnSignupCommand()
        {
            try
            {
                if (confpass == password)
                {
                    RegisterDTO dto = new RegisterDTO()
                    {
                        Email = email,
                        Username = username,
                        Password = password,
                        Name = name,
                        DateOfBirth = birthday,
                        FavoriteBar = null,
                        FavoriteDrink = null,
                    };

                    bool result = await RestClient.RegisterAsync(dto);

                    if (result)
                    {
                        await Alerter.Alert("Notice",
                            "Your account has been registered!", "OK");
                        await _navigationService.GoBackAsync();
                    }
                    else
                        await Alerter.Alert("Error",
                            "Something went wrong in the registration!", "OK");
                }
                else
                    await Alerter.Alert("Error",
                        "Passwords do not match!", "OK");
            }
            catch (Exception e)
            {
                await Alerter.Alert("Error",
                    e.Message, "OK");
            }
        }

        #endregion
    }
}