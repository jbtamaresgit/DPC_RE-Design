using Prism.Commands;
using Prism.Navigation;
using dpc_app.Common.Modules.Matches;
using System;
using dpc_app.Common.Modules.Roster;

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

        public void Initialize(INavigationParameters parameters)
        {
            
        }
    }
}
