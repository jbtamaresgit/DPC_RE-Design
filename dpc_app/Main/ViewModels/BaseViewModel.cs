using dpc_app.Common.Constants;
using Prism.Mvvm;
using Prism.Navigation;

namespace Main.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        public readonly INavigationService NavigationService;

        public BaseViewModel()
        {

        }

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        private bool _IsBusy = false;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { SetProperty(ref _IsBusy, value); }
        }

        private NavigationMode _NavigationMode;
        public NavigationMode NavigationMode
        {
            get { return _NavigationMode; }
            set { SetProperty(ref _NavigationMode, value); }
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            NavigationMode = parameters.GetNavigationMode();
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            NavigationMode = parameters.GetNavigationMode();
        }
    }
}
