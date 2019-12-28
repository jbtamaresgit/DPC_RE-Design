using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Support.Design.Internal;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;
using dpc_app.Droid.CustomRenderers.CustomTabbedPage;
using dpc_app.SharedResources.CustomControls.CustomTabbedPage;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

[assembly: ExportRenderer(typeof(CustomTabbedPageControl), typeof(CustomTabbedPageRenderer))]
namespace dpc_app.Droid.CustomRenderers.CustomTabbedPage
{
    public class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        //TabLayout TabLayout;
        BottomNavigationView bottomNavigationView;

        public CustomTabbedPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TabbedPage> e)
        {
            base.OnElementChanged(e);

            if(e.NewElement != null)
            {
                bottomNavigationView = (GetChildAt(0) as Android.Widget.RelativeLayout).GetChildAt(1) as BottomNavigationView;
                ChangeFont();
            }
        }

        void ChangeFont()
        {
            BottomNavigationMenuView bottomNavMenuView = bottomNavigationView.GetChildAt(0) as BottomNavigationMenuView;

            for (int i = 0; i < bottomNavMenuView.ChildCount; i++)
            {
                BottomNavigationItemView item = bottomNavMenuView.GetChildAt(i) as BottomNavigationItemView;
                Android.Views.View itemTitle = item.GetChildAt(1);

                TextView smallTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(0));
                TextView largeTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(1));

                smallTextView.SetTextSize(ComplexUnitType.Sp, 10);
                largeTextView.SetTextSize(ComplexUnitType.Sp, 10);
            }
        }

        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);

        //    TabLayout = (TabLayout)ViewGroup.GetChildAt(1);

        //    CustomTabbedPageControl Control = (CustomTabbedPageControl)sender;

        //    if (Control != null)
        //    {
        //        for (int x = 0; x < TabLayout.TabCount; x++)
        //        {
        //            TabLayout.Tab tab = TabLayout.GetTabAt(x);
        //            Android.Graphics.Drawables.Drawable icon = tab.Icon;

        //            if (icon != null)
        //            {
        //                Android.Graphics.Color color = tab.IsSelected ? Control.SelectedTextColor.ToAndroid() : Control.UnSelectedTextColor.ToAndroid();
        //                icon.SetColorFilter(color, PorterDuff.Mode.SrcIn);
        //            }
        //        }
        //    }
        //}
    }
}