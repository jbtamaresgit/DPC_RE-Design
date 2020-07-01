using dpc_app.Common.Modules.Fantasy;
using Main.Models;
using MvvmHelpers;
using Prism.Commands;
using Prism.Navigation;

namespace Main.ViewModels
{
    public class FantasyViewModel : BaseViewModel, IInitialize
    {
        public FantasyViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private DelegateCommand<FantasyTournamentModel> _SelectCommand;
        public DelegateCommand<FantasyTournamentModel> SelectCommand =>
            _SelectCommand ?? (_SelectCommand = new DelegateCommand<FantasyTournamentModel>(ExecuteSelectCommand));

        void ExecuteSelectCommand(FantasyTournamentModel SelectedItem)
        {
            NavigationParameters NavigationParameters = new NavigationParameters
            {
                { FantasyParameterConsts.FantasyTournamentContent, SelectedItem }
            };

            NextAsync(FantasyPages.MainFantasyView, NavigationParameters);
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
                    RosterStatus = "ROSTER SET",
                    SelectCommand = SelectCommand
                },
                new FantasyTournamentModel
                {
                    Status = "UPCOMING",
                    Title = "DreamLeague Season 13",
                    Type = "MAIN EVENT",
                    RosterStatus = "ROSTER SET",
                    SelectCommand = SelectCommand
                }
            };
        }
    }
}
