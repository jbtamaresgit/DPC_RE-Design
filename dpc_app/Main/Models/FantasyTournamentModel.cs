using System.Windows.Input;

namespace Main.Models
{
    public class FantasyTournamentModel
    {
        public string Status { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string RosterStatus { get; set; }
        public ICommand SelectCommand { get; set; }
    }
}
