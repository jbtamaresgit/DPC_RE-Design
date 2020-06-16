using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Predictions.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPredictions : ContentPage
    {
        public MainPredictions()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception e)
            {

            }
        }
    }
}