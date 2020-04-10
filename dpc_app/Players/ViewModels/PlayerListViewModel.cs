using Prism.Navigation;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Players.ViewModels
{
    public class PlayerListViewModel : BaseViewModel
    {
        public PlayerListViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public string ImageSrc { get { return "https://i.axs.com/2019/11/67184-image_5dd4889332d17.jpg"; } }

        public string PageTitle { get { return "Players"; } }

        private ObservableCollection<Point> _Points;
        public ObservableCollection<Point> Points
        {
            get { return _Points; }
            set { SetProperty(ref _Points, value); }
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
