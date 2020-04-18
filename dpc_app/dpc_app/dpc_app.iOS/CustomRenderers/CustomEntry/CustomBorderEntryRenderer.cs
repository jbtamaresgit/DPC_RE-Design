using CoreAnimation;
using dpc_app.iOS.CustomRenderers.CustomEntry;
using dpc_app.SharedResources.CustomControls.CustomEntry;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomBorderEntryControl), typeof(CustomBorderEntryRenderer))]
namespace dpc_app.iOS.CustomRenderers.CustomEntry
{
    public class CustomBorderEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;

                CustomBorderEntryControl entry = (Element as CustomBorderEntryControl);

                if (entry != null && entry.HasBorder)
                {
                    DrawBorder(entry);
                }

            }
        }

        void DrawBorder(CustomBorderEntryControl entry)
        {
            CALayer borderLayer = new CALayer
            {
                MasksToBounds = true,
                Frame = new CoreGraphics.CGRect(0f, Frame.Height / 2, Frame.Width, 1f),
                BorderColor = entry.BorderColor.ToCGColor(),
                BorderWidth = 1.0f
            };

            Control.Layer.AddSublayer(borderLayer);
            //Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}