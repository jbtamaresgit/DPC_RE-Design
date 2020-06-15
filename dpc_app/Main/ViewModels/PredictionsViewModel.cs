using dpc_app.Common.Modules.Home.Players;
using dpc_app.Common.Modules.Predictions;
using dpc_app.Common.Modules.Roster;
using Main.Models;
using MvvmHelpers;
using Prism.Commands;
using Prism.Navigation;
using System;

namespace Main.ViewModels
{
    public class PredictionsViewModel : BaseViewModel, IInitialize
    {
        public PredictionsViewModel(INavigationService navigationService) : base(navigationService)
        {
        }


        private ObservableRangeCollection<PredictionTournamentModel> _Tournaments;
        public ObservableRangeCollection<PredictionTournamentModel> Tournaments
        {
            get { return _Tournaments; }
            set { SetProperty(ref _Tournaments, value); }
        }

        private DelegateCommand<PredictionTournamentModel> _SelectTournamentCommand;

        public DelegateCommand<PredictionTournamentModel> SelectTournamentCommand =>
            _SelectTournamentCommand ?? (_SelectTournamentCommand = new DelegateCommand<PredictionTournamentModel>(ExecuteSelectTournamentCommand));

        void ExecuteSelectTournamentCommand(PredictionTournamentModel Tournament)
        {
            NavigationService.NavigateAsync(PredictionPages.MainPredictions);
        }

        public void Initialize(INavigationParameters parameters)
        {
            Tournaments = new ObservableRangeCollection<PredictionTournamentModel>()
            {
                new PredictionTournamentModel
                {
                    TournamentImageSrc = "https://steamcdn-a.akamaihd.net/apps/dota2/images/blog/play/dota_heroes.png",
                    Title = "WePlay! Bukovel Minor 2020",
                    Status = "On-Going",
                    Duration = $"{new DateTime(2019, 12, 05).ToString("dd MMMM")} - {new DateTime(2020, 01, 14).ToString("dd MMMM")}",
                    SelectTournamentCommand = SelectTournamentCommand
                }
            };
        }
    }
}
