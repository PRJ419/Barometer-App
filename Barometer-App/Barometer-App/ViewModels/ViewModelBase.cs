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
        protected IRestClient RestClient = new StubRestClient();
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
    }
}
