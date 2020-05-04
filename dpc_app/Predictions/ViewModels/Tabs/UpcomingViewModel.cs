using dpc_app.Common.Helpers.Collections;
using MvvmHelpers;
using Predictions.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Predictions.ViewModels.Tabs
{
    public class UpcomingViewModel : BaseViewModel, IInitialize
    {
        public UpcomingViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private ObservableRangeCollection<GroupingHelper<string, UpcomingMatchesModel>> _UpcomingMatches;
        public ObservableRangeCollection<GroupingHelper<string, UpcomingMatchesModel>> UpcomingMatches
        {
            get { return _UpcomingMatches; }
            set { SetProperty(ref _UpcomingMatches, value); }
        }

        private DelegateCommand<UpcomingMatchesModel> _SelectCommand;

        public DelegateCommand<UpcomingMatchesModel> SelectCommand =>
            _SelectCommand ?? (_SelectCommand = new DelegateCommand<UpcomingMatchesModel>(ExecuteSelectCommand));

        async void ExecuteSelectCommand(UpcomingMatchesModel Item)
        {
            await NavigationService.NavigateAsync("WagerPopUpView");
        }

        public void Initialize(INavigationParameters parameters)
        {
            DateTime date_1 = DateTime.Now;
            DateTime date_2 = new DateTime(2020, 5, 1, 7, 10, 24);


            List<UpcomingMatchesModel> list = new List<UpcomingMatchesModel>()
            {
                new UpcomingMatchesModel
                {
                    MatchID = 1,
                    TeamA_ImgSource = "https://liquipedia.net/commons/images/thumb/8/89/FlyToMoon_Logo.png/600px-FlyToMoon_Logo.png",
                    TeamA_Name = "FlyToMoon",
                    TeamB_ImgSource = "https://liquipedia.net/commons/images/thumb/d/d6/Natus_Vincere.png/600px-Natus_Vincere.png",
                    TeamB_Name = "Natus Vincere",
                    GameRound = "Game 1",
                    GameScore = "0 : 0",
                    MatchSchedule = $"{date_1.DayOfWeek}    {date_1.Day} {date_1.ToString("MMMM")}",
                    MatchDate = date_1,
                    MatchDay = $"{date_1.DayOfWeek}",
                    MatchTime = $"{date_1.ToString("HH:mm")}",
                    PredictedTeam = "Natus Vincere",
                    ReturnShards = $" {100} Shards",
                    WagerShards = $" {100} Shards",
                    SelectCommand = SelectCommand
                },
                new UpcomingMatchesModel
                {
                    MatchID = 2,
                    TeamA_ImgSource = "https://liquipedia.net/commons/images/thumb/8/89/FlyToMoon_Logo.png/600px-FlyToMoon_Logo.png",
                    TeamA_Name = "FlyToMoon",
                    TeamB_ImgSource = "https://liquipedia.net/commons/images/thumb/d/d6/Natus_Vincere.png/600px-Natus_Vincere.png",
                    TeamB_Name = "Natus Vincere",
                    GameRound = "Game 1",
                    GameScore = "0 : 0",
                    MatchSchedule = $"{date_1.DayOfWeek}    {date_2.Day} {date_2.ToString("MMMM")}",
                    MatchDate = date_2,
                    MatchTime = $"{date_2.ToString("HH:mm")}",
                    MatchDay =  $"{date_2.DayOfWeek}",
                    PredictedTeam = "None",
                    ReturnShards = $" {0} Shards",
                    WagerShards = $" {0} Shards",
                    SelectCommand = SelectCommand
                }
            };

            List<GroupingHelper<string, UpcomingMatchesModel>> sorted = list.OrderBy(x => x.MatchDate.TimeOfDay)
                    .GroupBy(x => x.MatchSchedule)
                    .Select(x => new GroupingHelper<string, UpcomingMatchesModel>(x.Key, x))
                    .ToList();

            UpcomingMatches = new ObservableRangeCollection<GroupingHelper<string, UpcomingMatchesModel>>();
            UpcomingMatches.AddRange(sorted);
        }
    }
}
