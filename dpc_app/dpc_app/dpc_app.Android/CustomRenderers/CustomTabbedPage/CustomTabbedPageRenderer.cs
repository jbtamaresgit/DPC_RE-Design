using Android.Content;
using Android.Support.Design.Internal;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Widget;
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
        //TabLayout TabLayout;

        BottomNavigationView bottomNavigationView;
        BottomNavigationMenuView bottomNavMenuView;
        int lastItemId = -1;

        public CustomTabbedPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                bottomNavigationView = (GetChildAt(0) as Android.Widget.RelativeLayout).GetChildAt(1) as BottomNavigationView;
                bottomNavigationView.NavigationItemSelected += BottomNavigationView_Selected;
                ChangeFont();
            }

            if(e.OldElement != null)
            {
                bottomNavigationView.NavigationItemSelected -= BottomNavigationView_Selected;
            }
        }

        void ChangeFont()
        {
            bottomNavMenuView = bottomNavigationView.GetChildAt(0) as BottomNavigationMenuView;

            for (int i = 0; i < bottomNavMenuView.ChildCount; i++)
            {
                BottomNavigationItemView item = bottomNavMenuView.GetChildAt(i) as BottomNavigationItemView;
                Android.Views.View itemTitle = item.GetChildAt(1);

                TextView smallTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(0));
                TextView largeTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(1));

                lastItemId = bottomNavMenuView.SelectedItemId;

                smallTextView.SetTextSize(ComplexUnitType.Sp, 10);
                largeTextView.SetTextSize(ComplexUnitType.Sp, 10);
            }
        }

        private void BottomNavigationView_Selected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            if (lastItemId != -1)
            {
                SetTabLargeTextSize(bottomNavMenuView.GetChildAt(lastItemId) as BottomNavigationItemView);
            }

            SetTabLargeTextSize(bottomNavMenuView.GetChildAt(e.Item.ItemId) as BottomNavigationItemView);

            this.OnNavigationItemSelected(e.Item);

            lastItemId = e.Item.ItemId;
        }

        void SetTabLargeTextSize(BottomNavigationItemView bottomNavigationItemView)
        {
            Android.Views.View itemTitle = bottomNavigationItemView.GetChildAt(1);
            TextView largeTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(1));
            largeTextView.SetTextSize(ComplexUnitType.Sp, 10);
        }

        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);

        //    //TabLayout = (TabLayout)ViewGroup.GetChildAt(1);

        //    CustomTabbedPageControl Control = (CustomTabbedPageControl)sender;

        //    if (Control != null)
        //    {
        //        bottomNavigationView = (GetChildAt(0) as Android.Widget.RelativeLayout).GetChildAt(1) as BottomNavigationView;
        //        ChangeFont();

        //        //for (int x = 0; x < TabLayout.TabCount; x++)
        //        //{
        //        //    TabLayout.Tab tab = TabLayout.GetTabAt(x);
        //        //    Android.Graphics.Drawables.Drawable icon = tab.Icon;

        //        //    if (icon != null)
        //        //    {
        //        //        Android.Graphics.Color color = tab.IsSelected ? Control.SelectedTextColor.ToAndroid() : Control.UnSelectedTextColor.ToAndroid();
        //        //        icon.SetColorFilter(color, PorterDuff.Mode.SrcIn);
        //        //    }
        //        //}
        //    }
        //}
    }
}