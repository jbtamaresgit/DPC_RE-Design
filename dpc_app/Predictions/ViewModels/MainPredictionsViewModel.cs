using dpc_app.SharedResources.Events.Predictions;
using Prism.Events;
using Prism.Navigation;

namespace Predictions.ViewModels
{
    public class MainPredictionsViewModel : BaseViewModel, IDestructible
    {
        IEventAggregator EventAggregator;

        public MainPredictionsViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService)
        {
            EventAggregator = eventAggregator;

            SubscribeEvents();
        }

        public void Destroy()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            EventAggregator.GetEvent<PredictionShardEvent>().Unsubscribe(UpdateShards);
        }

        private void SubscribeEvents()
        {
            EventAggregator.GetEvent<PredictionShardEvent>().Subscribe(UpdateShards, ThreadOption.UIThread);
        }

        private void UpdateShards(int obj)
        {
            Shards -= obj;
            base.ParameterShards = Shards;
        }

        private int _SelectedViewModelIndex;
        public int SelectedViewModelIndex
        {
            get { return _SelectedViewModelIndex; }
            set { SetProperty(ref _SelectedViewModelIndex, value); }
        }

        private int _Shards;
        public int Shards
        {
            get { return _Shards; }
            set { SetProperty(ref _Shards, value); }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (NavigationMode.Equals(NavigationMode.New))
            {
                InitializeItem();
            }  
        }

        private void InitializeItem()
        {
            Shards = 999999;
            base.ParameterShards = Shards;
        }
    }
}
