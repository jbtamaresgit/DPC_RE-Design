using Main.Models;
using MvvmHelpers;
using Prism.Navigation;

namespace Main.ViewModels
{
    public class FantasyViewModel : BaseViewModel, IInitialize
    {
        public FantasyViewModel()
        {

        }

        private ObservableRangeCollection<FantasyTournamentModel> _FantasyTournaments;
        public ObservableRangeCollection<FantasyTournamentModel> FantasyTournaments
        {
            get { return _FantasyTournaments; }
            set { SetProperty(ref _FantasyTournaments, value); }
        }

        public void Initialize(INavigationParameters parameters)
        {
            FantasyTournaments = new ObservableRangeCollection<FantasyTournamentModel>()
            {
                new FantasyTournamentModel
                {
                    Status = "UPCOMING",
                    Title = "DreamLeague Season 13",
                    Type = "MAIN EVENT",
                    RosterStatus = "ROSTER SET"
                },
                new FantasyTournamentModel
                {
                    Status = "UPCOMING",
                    Title = "DreamLeague Season 13",
                    Type = "MAIN EVENT",
                    RosterStatus = "ROSTER SET"
                }
            };
        }
    }
}
