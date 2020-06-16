using Prism.Navigation;

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
    }
}
