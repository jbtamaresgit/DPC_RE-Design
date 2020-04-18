using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using dpc_app.Droid.CustomRenderers.CustomEntry;
using dpc_app.SharedResources.CustomControls.CustomEntry;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomBorderEntryControl), typeof(CustomBorderEntryRenderer))]
namespace dpc_app.Droid.CustomRenderers.CustomEntry
{
    public class CustomBorderEntryRenderer : EntryRenderer
    {
        public CustomBorderEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            CustomBorderEntryControl entry = Element as CustomBorderEntryControl;

            if (Control != null)
            {
                if (!entry.HasBorder)
                {
                    Control.Background = null;
                }
                else
                {
                    GradientDrawable gd = new GradientDrawable();
                    //gd.SetColor(entry.BorderColor.ToAndroid());
                    Control.Background.SetColorFilter(entry.BorderColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
                }
            }


        }
    }
}