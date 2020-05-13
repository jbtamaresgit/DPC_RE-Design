using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Predictions.Views.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WagerPopUpView : PopupPage
    {
        const int dividend = 10;
        int SliderXValue = 0;

        public WagerPopUpView()
        {
            InitializeComponent();
        }

        private void SliderWager_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            double newStep = Math.Round(e.NewValue / dividend);
            SliderWager.Value = newStep * dividend;
            lblSliderValue.Text = SliderWager.Value.ToString();

            if (SliderWager.Value >= 0 && SliderWager.Value <= 20)
            {
                SliderXValue = 45;        
            }
            else if(SliderWager.Value >= 30 && SliderWager.Value <= 40)
            {
                SliderXValue = 40;
            }
            else
            {
                SliderXValue = 37;
            }


            double TranslateXValue = SliderWager.Value * ((SliderWager.Width - SliderXValue) / SliderWager.Maximum);
            lblSliderValue.TranslateTo(TranslateXValue, 0, 100);
        }
    }
}