using Prism.Navigation;
using System;

namespace Predictions.ViewModels
{
    public class MainPredictionsViewModel : BaseViewModel
    {
        public MainPredictionsViewModel(INavigationService navigationService) : base(navigationService)
        {
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

            InitializeItem();
        }

        private void InitializeItem()
        {
            Shards = 999999;
        }
    }
}
