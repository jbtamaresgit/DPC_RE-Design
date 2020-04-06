using MvvmHelpers;
using Prism.Commands;
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

        private ObservableRangeCollection<TournamentUpdateContentModel> _TournamentUpdates;
        public ObservableRangeCollection<TournamentUpdateContentModel> TournamentUpdates
        {
            get { return _TournamentUpdates; }
            set { SetProperty(ref _TournamentUpdates, value); }
        }

        private DelegateCommand _NavigateBackCommand;
        public DelegateCommand NavigateBackCommand =>
            _NavigateBackCommand ?? (_NavigateBackCommand = new DelegateCommand(ExecuteNavigateBackCommand));

        void ExecuteNavigateBackCommand()
        {
            base.GoBackAsync();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            TournamentUpdates = new ObservableRangeCollection<TournamentUpdateContentModel>
            {
                new TournamentUpdateContentModel
                {
                    TournamentImageSrc = "https://dotesports-media.nyc3.cdn.digitaloceanspaces.com/wp-content/uploads/2020/02/05134451/DOTA2_KYIV.jpg",
                    TeamImageSrc = "https://liquipedia.net/commons/images/thumb/9/94/Team_Aster_logo.png/600px-Team_Aster_logo.png",
                    TeamName = "Team Aster",
                    TournamentUpdateContent = " has won StarLadder ImbaTV Dota 2 Minor!",
                    DPCPoints = "140 DPC POINTS",
                    DPCPrize = "$72,000 USD"
                }
            };
        }
    }
}
