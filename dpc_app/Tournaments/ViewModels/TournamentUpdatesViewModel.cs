using Prism.Navigation;
using Tournaments.Models;

namespace Tournaments.ViewModels
{
    public class TournamentUpdatesViewModel : BaseViewModel
    {
        public TournamentUpdatesViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public string ImageSrc { get { return "https://i.pinimg.com/originals/36/5b/ae/365baefebed96107b34ee5e30a6a9d15.jpg"; } }

        public string PageTitle { get { return "Tournament Updates"; } }

        private TournamentUpdateContentModel _Content;
        public TournamentUpdateContentModel Content
        {
            get { return _Content; }
            set { SetProperty(ref _Content, value); }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Content = new TournamentUpdateContentModel
            {
                TeamName = "Team Aster",
                TournamentUpdateContent = " has won StarLadder ImbaTV Dota 2 Minor!",
                DPCPoints = "140 DPC POINTS",
                DPCPrize = "$72,000 USD"
            };
        }
    }
}
