using Android.Support.Design.BottomNavigation;
using Android.Support.Design.Widget;
using Android.Views;
using dpc_app.Droid.PlatformEffects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly:ResolutionGroupName("PlatformEffects")]
[assembly:ExportEffect(typeof(NoTabShiftEffect), "NoTabShiftEffect")]
namespace dpc_app.Droid.PlatformEffects
{
    public class NoTabShiftEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (!(Container.GetChildAt(0) is ViewGroup layout))
            {
                return;
            }

            if(!(layout.GetChildAt(0) is BottomNavigationView bottomNavigationView))
            {
                return;
            }

            bottomNavigationView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityLabeled;
        }

        protected override void OnDetached()
        {
           
        }
    }
}