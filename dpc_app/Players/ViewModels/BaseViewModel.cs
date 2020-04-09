using Prism.Mvvm;
using Prism.Navigation;

namespace Players.ViewModels
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

        public async void GoBackAsync()
        {
            await NavigationService.GoBackAsync();
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }
    }
}
