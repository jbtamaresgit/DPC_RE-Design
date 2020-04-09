using Prism.Navigation;

namespace Players.ViewModels
{
    public class PlayerListViewModel : BaseViewModel
    {
        public PlayerListViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public string ImageSrc { get { return "https://i.axs.com/2019/11/67184-image_5dd4889332d17.jpg"; } }

        public string PageTitle { get { return "Players"; } }


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
