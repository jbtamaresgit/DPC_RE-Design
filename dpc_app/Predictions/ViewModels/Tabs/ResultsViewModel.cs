using dpc_app.Common.Helpers.Collections;
using MvvmHelpers;
using Predictions.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Predictions.ViewModels.Tabs
{
    public class ResultsViewModel : BaseViewModel, IInitialize
    {
        public ResultsViewModel(INavigationService navigationService) : base(navigationService)
        {
        }


        private List<ResultMatchesModel> ResultsMatchesContainer;
        private Color WinIndicatorColor = Color.FromHex("#00B918");
        private Color LoseIndicatorColor = Color.FromHex("#FF0000");

        private ObservableRangeCollection<GroupingHelper<string, ResultMatchesModel>> _ResultsMatches;
        public ObservableRangeCollection<GroupingHelper<string, ResultMatchesModel>> ResultsMatches
        {
            get { return _ResultsMatches; }
            set { SetProperty(ref _ResultsMatches, value); }
        }

        private DelegateCommand<ResultMatchesModel> _SelectCommand;
        public DelegateCommand<ResultMatchesModel> SelectCommand =>
            _SelectCommand ?? (_SelectCommand = new DelegateCommand<ResultMatchesModel>(ExecuteSelectCommand));

        void ExecuteSelectCommand(ResultMatchesModel SelectedItem)
        {

        }

        public void Initialize(INavigationParameters parameters)
        {
            InitializeCollection();
        }

        private void InitializeCollection()
        {
            DateTime date_1 = DateTime.Now;
            DateTime date_2 = new DateTime(2020, 5, 1, 7, 10, 24);


            ResultsMatchesContainer = new List<ResultMatchesModel>()
            {
                new ResultMatchesModel
                {
                    MatchID = 1,
                    TeamA_ImgSource = "https://liquipedia.net/commons/images/thumb/8/89/FlyToMoon_Logo.png/600px-FlyToMoon_Logo.png",
                    TeamA_Name = "FlyToMoon",
                    TeamB_ImgSource = "https://liquipedia.net/commons/images/thumb/d/d6/Natus_Vincere.png/600px-Natus_Vincere.png",
                    TeamB_Name = "Natus Vincere",
                    GameScore = "0 : 2",
                    MatchSchedule = $"{date_1.DayOfWeek}    {date_1.Day} {date_1.ToString("MMMM")}",
                    MatchDate = date_1,
                    MatchDay = $"{date_1.DayOfWeek}",
                    PredictedTeam = "Natus Vincere",
                    ReturnShards = $" {200} Shards",
                    WagerShards = $" {100} Shards",
                    SelectCommand = SelectCommand,
                    IsPredicted = true,
                    GameResult = "WIN",
                    GameResultColorIndicator = WinIndicatorColor
                },
                new ResultMatchesModel
                {
                    MatchID = 2,
                    TeamA_ImgSource = "https://liquipedia.net/commons/images/thumb/8/89/FlyToMoon_Logo.png/600px-FlyToMoon_Logo.png",
                    TeamA_Name = "FlyToMoon",
                    TeamB_ImgSource = "https://liquipedia.net/commons/images/thumb/d/d6/Natus_Vincere.png/600px-Natus_Vincere.png",
                    TeamB_Name = "Natus Vincere",
                    GameScore = "2 : 0",
                    MatchSchedule = $"{date_1.DayOfWeek}    {date_2.Day} {date_2.ToString("MMMM")}",
                    MatchDate = date_2,
                    MatchDay =  $"{date_2.DayOfWeek}",
                    PredictedTeam = "Natus Vincere",
                    ReturnShards = $" {200} Shards",
                    WagerShards = $" {100} Shards",
                    SelectCommand = SelectCommand,
                    IsPredicted = true,
                    GameResult = "LOSE",
                    GameResultColorIndicator = LoseIndicatorColor
                }
            };

            List<GroupingHelper<string, ResultMatchesModel>> sorted = ResultsMatchesContainer.OrderBy(x => x.MatchDate.TimeOfDay)
                    .GroupBy(x => x.MatchSchedule)
                    .Select(x => new GroupingHelper<string, ResultMatchesModel>(x.Key, x))
                    .ToList();

            ResultsMatches = new ObservableRangeCollection<GroupingHelper<string, ResultMatchesModel>>();
            ResultsMatches.ReplaceRange(sorted);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

    }
}
