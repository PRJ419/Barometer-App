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
    /// ViewModel for the BarSignup View
    /// </summary>
    public class BarSignupViewModel : ViewModelBase
    {
        /// <summary>
        /// Alerter used for popups
        /// </summary>
        private IAlerter Alerter;
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// Property for hold the incoming bar object information
        /// </summary>
        private RegisterBarDTO _bar;

        /// <summary>
        /// Bindable property for the View
        /// </summary>
        public RegisterBarDTO Bar
        {
            get => _bar;
            set => SetProperty(ref _bar, value);
        }

        /// <summary>
        /// Constructor for the ViewModel of the BarSignup View
        /// Initializes Bar and RestClient
        /// </summary>
        /// <param name="navigationService">
        /// Navigation service provided by Prism
        /// </param>
        public BarSignupViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Bar = new RegisterBarDTO();
            Alerter = new Alerter();
            Title = "Bar Sign Up";
        }

        /// <summary>
        /// Constructor for testing purposes
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="restClient"></param>
        public BarSignupViewModel(INavigationService navigationService, IRestClient restClient, IAlerter alert) : base(restClient)
        {
            NavigationService = navigationService;
            Bar = new RegisterBarDTO();
            Alerter = alert;
        }

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _signUpCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand SignUpCommand => _signUpCommand ?? (_signUpCommand = new DelegateCommand(OnSignUp));

        /// <summary>
        /// Logic that defines the behaviour for the Signup command
        /// </summary>
        private async void OnSignUp()
        {
            try
            {
                if (Bar.Password == ConfirmPassword)
                {
                    bool result = await RestClient.CreateBar(Bar);
                    if (result)
                    {
                        await Alerter.Alert("Notice",
                            "Your Bar and Bar Representative account have been registered!", "OK");
                        await NavigationService.GoBackAsync();
                    }
                    else
                        await Alerter.Alert("Error",
                            "Something went wrong in the registration!", "OK");
                }
                else
                    await Alerter.Alert("Error", "Passwords do not match", "OK");
            }
            catch (Exception e)
            {
                    await Alerter.Alert("Error",
                        e.Message, "OK");
            }
        }
    }
}