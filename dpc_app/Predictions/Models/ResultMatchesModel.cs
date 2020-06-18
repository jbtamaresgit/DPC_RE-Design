using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Predictions.Models
{
    public class ResultMatchesModel
    {
        public int MatchID { get; set; }
        public string TeamA_ImgSource { get; set; }
        public string TeamA_Name { get; set; }
        public string TeamB_ImgSource { get; set; }
        public string TeamB_Name { get; set; }
        public string GameRound { get; set; }
        public string GameScore { get; set; }
        public string PredictedTeam { get; set; }
        public string WagerShards { get; set; }
        public string ReturnShards { get; set; }
        public string MatchTime { get; set; }
        public DateTime MatchDate { get; set; }
        public string MatchSchedule { get; set; }
        public string MatchDay { get; set; }
        public ICommand SelectCommand { get; set; }
        public bool IsPredicted { get; set; }
        public Color GameResultColorIndicator { get; set; }
        public string GameResult { get; set; }
    }
}
