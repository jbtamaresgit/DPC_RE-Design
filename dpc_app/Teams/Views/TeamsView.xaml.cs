using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teams.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamsView : ContentPage
    {
        readonly int entryEmptyCounter = 0;
        double searchBoxWidthStart = 0;
        bool IsSearchOpen = false;

        public TeamsView()
        {
            InitializeComponent();
            InitContent();
        }

        private void InitContent()
        {
            closeButton.IsVisible = false;
            clearButton.IsVisible = false;
            searchEntry.IsVisible = false;
            searchBoxWidthStart = SearchBoxView.Width;
        }

        private void SearchTappedGesture_Tapped(object sender, EventArgs e)
        {
            if (!IsSearchOpen)
            {
                DisplayInfo mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
                int currentMargin = 40;
                double endPoint = (mainDisplayInfo.Width / mainDisplayInfo.Density) - currentMargin;

                new Animation(callback: x => SearchBoxView.WidthRequest = x, start: searchBoxWidthStart,
                   end: endPoint).Commit(this, "OpenSearchBoxAnimation", 16, 1000, Easing.SinIn, finished: (x, y) =>
                   {
                       searchEntry.IsVisible = true;
                       closeButton.IsVisible = true;
                       searchEntry.Focus();
                   });

                IsSearchOpen = true;
            }

        }

        private void searchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchEntry.Text.Length > entryEmptyCounter)
            {
                closeButton.IsVisible = false;
                clearButton.IsVisible = true;
            }

            if (searchEntry.Text.Length.Equals(entryEmptyCounter))
            {
                closeButton.IsVisible = true;
                clearButton.IsVisible = false;
            }
        }

        private void closeButtonGestureTap_Tapped(object sender, EventArgs e)
        {
            DisplayInfo mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            int currentMargin = 40;
            double startPoint = (mainDisplayInfo.Width / mainDisplayInfo.Density) - currentMargin;
            closeButton.IsVisible = false;
            searchEntry.IsVisible = false;

            new Animation(callback: x => SearchBoxView.WidthRequest = x, start: startPoint,
               end: searchBoxWidthStart).Commit(this, "CloseSearchBoxAnimation", 16, 1000, Easing.SinIn);

            IsSearchOpen = false;
        }

        private void clearButtonGestureTap_Tapped(object sender, EventArgs e)
        {
            searchEntry.Text = string.Empty;
        }

        private void SearchContainerBoxViewTap_Tapped(object sender, EventArgs e)
        {
            if (IsSearchOpen)
            {
                searchEntry.Focus();
            }
        }
    }

}