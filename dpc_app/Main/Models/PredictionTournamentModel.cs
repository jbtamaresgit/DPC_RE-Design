using System.Windows.Input;

namespace Main.Models
{
    public class PredictionTournamentModel
    {
        public string TournamentImageSrc { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Duration { get; set; }
        public ICommand SelectTournamentCommand { get; set; }
    }
}
