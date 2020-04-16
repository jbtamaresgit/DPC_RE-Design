using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

            closeButton.IsVisible = false;

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

        private void GridSearchTappedGesture_Tapped(object sender, EventArgs e)
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            int currentMargin = 40;
            double endPoint = (mainDisplayInfo.Width / mainDisplayInfo.Density) - currentMargin;

            new Animation(callback: x => SearchBoxView.WidthRequest = x, start: SearchBoxView.Width,
               end: endPoint).Commit(this, "SearchBoxAnimation", 16, 1000, Easing.SinIn, finished: (x, y) =>
               {
                   closeButton.IsVisible = true;
               });
        }

    }
}