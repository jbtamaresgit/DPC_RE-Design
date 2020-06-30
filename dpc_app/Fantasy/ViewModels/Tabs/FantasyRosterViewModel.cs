using Prism.Navigation;

namespace Fantasy.ViewModels.Tabs
{
    public class FantasyRosterViewModel : BaseViewModel, IInitialize
    {
        public FantasyRosterViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public void Initialize(INavigationParameters parameters)
        {
          
        }

        private void InitializeCollection()
        {

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
