using Prism.Navigation;

namespace Fantasy.ViewModels
{
    public class MainFantasyViewModel : BaseViewModel
    {
        public MainFantasyViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public bool IsProfileVisible
        {
            get { return false; }
        }

        private int _SelectedViewModelIndex;
        public int SelectedViewModelIndex
        {
            get { return _SelectedViewModelIndex; }
            set { SetProperty(ref _SelectedViewModelIndex, value); }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}
