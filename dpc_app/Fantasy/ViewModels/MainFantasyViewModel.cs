using Prism.Navigation;

namespace Fantasy.ViewModels
{
    public class MainFantasyViewModel : BaseViewModel
    {
        public MainFantasyViewModel(INavigationService navigationService) : base(navigationService)
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
