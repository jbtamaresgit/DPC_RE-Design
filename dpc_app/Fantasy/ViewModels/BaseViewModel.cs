using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using Xamarin.Forms;

namespace Fantasy.ViewModels
{
    public class BaseViewModel : BindableBase, INavigatedAware
    {
        protected readonly INavigationService NavigationService;

        public BaseViewModel()
        {

        }

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        private NavigationMode _NavigationMode;
        public NavigationMode NavigationMode
        {
            get { return _NavigationMode; }
            set { SetProperty(ref _NavigationMode, value); }
        }

        private DelegateCommand _NavigateBackCommand;
        public DelegateCommand NavigateBackCommand =>
            _NavigateBackCommand ?? (_NavigateBackCommand = new DelegateCommand(ExecuteNavigateBackCommand));

        void ExecuteNavigateBackCommand()
        {

        }

        protected async void GoBackAsync(NavigationParameters parameters = null)
        {
            if(parameters != null)
            {
                await NavigationService.GoBackAsync(parameters);
            }
            else
            {
                await NavigationService.GoBackAsync();
            }

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            NavigationMode = parameters.GetNavigationMode();
        }
    }
}
