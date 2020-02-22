using Main.Models;
using MvvmHelpers;
using Prism.Navigation;
using System;

namespace Main.ViewModels
{
    public class PredictionsViewModel : BaseViewModel, IInitialize
    {
        public PredictionsViewModel()
        {

        }

        private ObservableRangeCollection<PredictionTournamentModel> _Tournaments;
        public ObservableRangeCollection<PredictionTournamentModel> Tournaments
        {
            get { return _Tournaments; }
            set { SetProperty(ref _Tournaments, value); }
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
                    Duration = $"{new DateTime(2019, 12, 05).ToString("dd MMMM")} - {new DateTime(2020, 01, 14).ToString("dd MMMM")}"
                }
            };
        }
    }
}
