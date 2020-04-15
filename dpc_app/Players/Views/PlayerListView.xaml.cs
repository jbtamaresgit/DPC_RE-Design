using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Players.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerListView : ContentPage
    {
        public PlayerListView()
        {
            InitializeComponent();

            InitTeamBadgeContainer();
        }

        private void InitTeamBadgeContainer()
        {
            //teamBadgeContainer.Points = new ObservableCollection<Point>
            //{
            //    new Point(5, 5),
            //    new Point(50, 5),
            //    new Point(50, 50),
            //    new Point(27, 70),
            //    new Point(5, 50)
            //};
        }
    }
}