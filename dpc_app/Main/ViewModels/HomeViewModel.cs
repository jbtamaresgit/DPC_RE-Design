using Prism.Commands;
using Prism.Navigation;
using dpc_app.Common.Modules.Matches;
using System;

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
            NavigationService.NavigateAsync(Pages.MainMatchesView);
        }

        public void Initialize(INavigationParameters parameters)
        {
            
        }
    }
}
