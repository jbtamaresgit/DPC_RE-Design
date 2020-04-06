using Prism.Commands;
using Prism.Navigation;
using dpc_app.Common.Modules.Matches;
using dpc_app.Common.Modules.Roster;
using dpc_app.Common.Modules.Home.Tournaments;
using dpc_app.Common.Modules.Home.DPC;

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

        public void Initialize(INavigationParameters parameters)
        {
            
        }
    }
}
