using System.Windows.Input;

namespace Teams.Models
{
    public class TeamModel
    {
        public int TeamID { get; set; }
        public string TeamImgSrc { get; set; }
        public string TeamName { get; set; }
        public string LatestAchievement { get; set; }
        public string TeamLocation { get; set; }
        public string PlayerImgSrc_1 { get; set; }
        public string PlayerImgSrc_2 { get; set; }
        public string PlayerImgSrc_3 { get; set; }
        public string PlayerImgSrc_4 { get; set; }
        public string PlayerImgSrc_5 { get; set; }
        public bool IsFavorite { get; set; }
        public ICommand FavoriteCommand { get; set; }
    }
}
