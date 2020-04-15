using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Players.Models
{
    public class PlayerModel
    {
        public int PlayerID { get; set; }
        public string PlayerImgSource { get; set; }
        public string PlayerName { get; set; }
        public string TeamName { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public bool IsFavorite { get; set; }
        public Color FavoriteIconColor { get; set; }
        public ObservableCollection<Point> Points { get; set; }
        public string TeamImgSource { get; set; }
        public ICommand IsFavoriteCommand { get; set; }

    }
}
