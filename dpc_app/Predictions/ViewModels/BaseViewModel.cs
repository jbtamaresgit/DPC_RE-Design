using dpc_app.Common.Modules.Predictions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Predictions.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        public readonly INavigationService NavigationService;

        public BaseViewModel()
        {

        }

        protected int ParameterShards;

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

        private DelegateCommand _NavigateBackCommand;
        public DelegateCommand NavigateBackCommand =>
            _NavigateBackCommand ?? (_NavigateBackCommand = new DelegateCommand(ExecuteNavigateBackCommand));

        void ExecuteNavigateBackCommand()
        {
            GoBackAsync();
        }

        public async void GoBackAsync()
        {
            NavigationParameters NavigationParameters = new NavigationParameters
            {
                { PredictionParameterConsts.PredictionShards, ParameterShards }
            };

            await NavigationService.GoBackAsync(NavigationParameters);
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
