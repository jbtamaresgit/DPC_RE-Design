namespace Matches.Models
{
    public class MatchesModel
    {
        public string TeamA_ImgSource { get; set; }
        public string TeamA_TeamName { get; set; }
        public string GameRound { get; set; }
        public string GameRoundScore { get; set; }
        public string GameTime { get; set; }
        public string TeamB_ImgSource { get; set; }
        public string TeamB_TeamName { get; set; }
        public bool IsLive { get; set; }
        public string GroupTitle { get; set; }
    }
}
