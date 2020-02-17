using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using dpc_app.SharedResources.CustomControls.CustomTabbedPage;

namespace Main.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPageView : CustomTabbedPageControl
    {
        public MainTabbedPageView()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}