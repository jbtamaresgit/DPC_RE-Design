using dpc_app.Common.Extensions;
using dpc_app.Common.Modules.Predictions;
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

        private bool _IsShardsVisible = false;
        public bool IsShardsVisible
        {
            get { return _IsShardsVisible; }
            set { SetProperty(ref _IsShardsVisible, value); }
        }

        private NavigationMode _NavigationMode;
        public NavigationMode NavigationMode
        {
            get { return _NavigationMode; }
            set { SetProperty(ref _NavigationMode, value); }
        }

        private string _Shards;
        public string Shards
        {
            get { return _Shards; }
            set { SetProperty(ref _Shards, value); }
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            NavigationMode = parameters.GetNavigationMode();
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            NavigationMode = parameters.GetNavigationMode();
            InitializeItems(parameters);
        }

        private void InitializeItems(INavigationParameters parameters)
        {
            switch (NavigationMode)
            {
                case NavigationMode.New:
                    Shards = StringFormatterExtension.DecimalFormatter(999999);
                    break;
                case NavigationMode.Back:
                    InitializePredictionShards(parameters);
                    break;
            }
        }

        void InitializePredictionShards(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(PredictionParameterConsts.PredictionShards))
            {
                Shards = StringFormatterExtension.DecimalFormatter((int)parameters[PredictionParameterConsts.PredictionShards]);
            }
           
        }
    }
}
