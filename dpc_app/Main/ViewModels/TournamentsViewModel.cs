using Main.Models;
using MvvmHelpers;
using Prism.Navigation;
using System;

namespace Main.ViewModels
{
    public class TournamentsViewModel : BaseViewModel, IInitialize
    {
        public TournamentsViewModel()
        {

        }

        private ObservableRangeCollection<TournamentModel> _Tournaments;
        public ObservableRangeCollection<TournamentModel> Tournaments
        {
            get { return _Tournaments; }
            set { SetProperty(ref _Tournaments, value); }
        }
        
        public void Initialize(INavigationParameters parameters)
        {
            double prize = 300000;
            DateTime startDate = new DateTime(2019, 12, 05);
            DateTime endDate = new DateTime(2020, 01, 14);

            Tournaments = new ObservableRangeCollection<TournamentModel>()
            {
                new TournamentModel
                {
                    Title = "WePlay! Bukovel Minor 2020",
                    Type = "MINOR",
                    Prize = prize.ToString("C0"),
                    Duration = $"{startDate.ToString("dd MMMM")} - {endDate.ToString("dd MMMM")}"
                }
            };
        }
    }
}
