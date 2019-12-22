using dpc_app.iOS.CustomRenderers;
using dpc_app.SharedResources.CustomControls.CustomTabbedPage;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomTabbedPageControl), typeof(CustomTabbedPageRenderer))]
namespace dpc_app.iOS.CustomRenderers
{
    public class CustomTabbedPageRenderer : TabbedRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
           
            CustomTabbedPageControl Control = (CustomTabbedPageControl)Element;
            if(Control != null)
            {
                TabbedPage tabs = Element as TabbedPage;

                TabBar.UnselectedItemTintColor = Control.UnSelectedIconColor.ToUIColor();
                TabBar.SelectedImageTintColor = Control.SelectedIconColor.ToUIColor();

                if(tabs != null)
                {
                    for(int x = 0; x < TabBar.Items.Length; x++)
                    {
                        UpdateTab(TabBar.Items[x], Control.SelectedTextColor.ToUIColor(), Control.UnSelectedTextColor.ToUIColor());
                    }
                }
            }

            base.ViewWillAppear(animated);

        }

        private void UpdateTab(UITabBarItem uITabBarItem, UIColor SelectedColor, UIColor UnSelectedColor)
        {
            if(uITabBarItem == null)
            {
                return;
            }

            uITabBarItem.SetTitleTextAttributes(new UITextAttributes
            {
               TextColor = SelectedColor
            }, UIControlState.Selected);

            uITabBarItem.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UnSelectedColor
            }, UIControlState.Normal);
        }
    }
}