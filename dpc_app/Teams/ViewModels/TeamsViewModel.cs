using Prism.Navigation;

namespace Teams.ViewModels
{
    public class TeamsViewModel : BaseViewModel
    {
        public TeamsViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        public string ImageSrc { get { return "https://www.jakpost.travel/wimages/large/127-1273501_epic-battle-desktop-wallpaper-dota-2-wallpaper-chaos.jpg"; } }

        public string PageTitle { get { return "Teams"; } }

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
