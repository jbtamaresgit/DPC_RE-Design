using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Matches.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMatchesView : ContentPage
    {
        public MainMatchesView()
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