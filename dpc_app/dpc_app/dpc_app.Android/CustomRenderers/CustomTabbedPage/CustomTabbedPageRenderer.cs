using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using dpc_app.Droid.CustomRenderers.CustomTabbedPage;
using dpc_app.SharedResources.CustomControls.CustomTabbedPage;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomTabbedPageControl), typeof(CustomTabbedPageRenderer))]
namespace dpc_app.Droid.CustomRenderers.CustomTabbedPage
{
    public class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        TabLayout TabLayout;

        public CustomTabbedPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            ViewPager = (ViewPager)ViewGroup.GetChildAt(0);
            TabLayout = (TabLayout)ViewGroup.GetChildAt(1);

            CustomTabbedPageControl Control = (CustomTabbedPageControl)sender;
            
            if(Control != null)
            {
                for (int x = 0; x < TabLayout.TabCount; x++)
                {
                    TabLayout.Tab tab = TabLayout.GetTabAt(x);
                    Android.Graphics.Drawables.Drawable icon = tab.Icon;

                    if (icon != null)
                    {
                        Android.Graphics.Color color = tab.IsSelected ? Control.SelectedTextColor.ToAndroid() : Control.UnSelectedTextColor.ToAndroid();
                        icon.SetColorFilter(color, PorterDuff.Mode.SrcIn);
                    }

                }
            }
        }


    }
}