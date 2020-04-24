using Prism.Commands;
using Prism.Navigation;
using dpc_app.Common.Modules.Matches;
using dpc_app.Common.Modules.Roster;
using dpc_app.Common.Modules.Home.Tournaments;
using dpc_app.Common.Modules.Home.DPC;
using dpc_app.Common.Modules.Home.Players;
using dpc_app.Common.Modules.Home.Teams;

namespace Main.ViewModels
{
    public class HomeViewModel : BaseViewModel, IInitialize
    {
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private DelegateCommand _MatchesCommand;
        public DelegateCommand MatchesCommand =>
            _MatchesCommand ?? (_MatchesCommand = new DelegateCommand(ExecuteMatchesCommand));

        void ExecuteMatchesCommand()
        {
            NavigationService.NavigateAsync(MatchesPages.MainMatchesView);
        }

        private DelegateCommand _RosterCommand;
        public DelegateCommand RosterCommand =>
            _RosterCommand ?? (_RosterCommand = new DelegateCommand(ExecuteRosterCommand));

        void ExecuteRosterCommand()
        {
            NavigationService.NavigateAsync(RosterPages.RosterUpdatesView);
        }

        private DelegateCommand _TournamentUpdatesCommand;
        public DelegateCommand TournamentUpdatesCommand =>
            _TournamentUpdatesCommand ?? (_TournamentUpdatesCommand = new DelegateCommand(ExecuteTournamentUpdatesCommand));

        void ExecuteTournamentUpdatesCommand()
        {
            NavigationService.NavigateAsync(TournamentUpdatesPages.TournamentUpdatesView);
        }

        private DelegateCommand _DPCStandingsCommand;
        public DelegateCommand DPCStandingsCommand =>
            _DPCStandingsCommand ?? (_DPCStandingsCommand = new DelegateCommand(ExecuteDPCStandingsCommand));

        void ExecuteDPCStandingsCommand()
        {
            NavigationService.NavigateAsync(DPCPages.DPCStandingsOverview);
        }

        private DelegateCommand _PlayersCommand;
        public DelegateCommand PlayersCommand =>
            _PlayersCommand ?? (_PlayersCommand = new DelegateCommand(ExecutePlayersCommand));

        void ExecutePlayersCommand()
        {
            NavigationService.NavigateAsync(PlayersPages.PlayerListView);
        }

        private DelegateCommand _TeamsCommand;
        public DelegateCommand TeamsCommand =>
            _TeamsCommand ?? (_TeamsCommand = new DelegateCommand(ExecuteTeamsCommand ));

        void ExecuteTeamsCommand ()
        {
            NavigationService.NavigateAsync(TeamsPages.TeamsView);
        }

        public void Initialize(INavigationParameters parameters)
        {
            
        }
    }
}
