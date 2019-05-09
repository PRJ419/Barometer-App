using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using RESTClient;

namespace Barometer_App.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        /// <summary>
        /// RestClient which is inherited.
        /// </summary>
        protected IRestClient RestClient = new RestClient();
        /// <summary>
        /// NavigationService which is inherited
        /// </summary>
        protected INavigationService NavigationService;

        /// <summary>
        /// Private version of the bindable property
        /// </summary>
        private string _title;
        /// <summary>
        /// Public bindable Title class for the View to bind to.
        /// </summary>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        /// <summary>
        /// Parameterless constructor for the other ViewModels to use easily
        /// </summary>
        public ViewModelBase() { }

        /// <summary>
        /// Constructor primarily used for testing purposes
        /// </summary>
        /// <param name="restClient"></param>
        public ViewModelBase(IRestClient restClient)
        {
            RestClient = restClient;
        }

        /// <summary>
        /// Is called when navigating from a page. 
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        /// <summary>
        /// Is called when navigated to a page. 
        /// </summary>
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        /// <summary>
        /// Is called when navigating to a page. 
        /// </summary>
        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        /// <summary>
        /// Is called when navigationPage is destroyed.
        /// </summary>
        public virtual void Destroy()
        {

        }

        #region NavCommand

        /// <summary>
        /// ICommand property that holds the DelegateCommand for later consumption
        /// </summary>
        private ICommand _navCommand;

        /// <summary>
        /// Bindable command that resolves to a DelegateCommand
        /// </summary>
        public ICommand NavCommand => _navCommand ?? (_navCommand = new DelegateCommand<string>(OnNav));

        /// <summary>
        /// Logic that defines behaviour for the navigation
        /// </summary>
        public async void OnNav(string navTo)
        {
            var navParams = new NavigationParameters();

            await NavigationService.NavigateAsync(navTo, navParams);
        }

        #endregion
    }
}
