using System.ComponentModel;
using Android.Content;
using dpc_app.Droid.CustomRenderers.CustomScrollView;
using dpc_app.SharedResources.CustomControls.CustomScrollView;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HiddenScrollViewControl), typeof(HiddenScrollViewRenderer))]
namespace dpc_app.Droid.CustomRenderers.CustomScrollView
{
    public class HiddenScrollViewRenderer : ScrollViewRenderer
    {
        public HiddenScrollViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if(this.Element == null)
            {
                return;
            }

            if(e.OldElement != null)
            {
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;
            }

            if(e.NewElement != null)
            {
                e.NewElement.PropertyChanged += OnElementPropertyChanged;
            }
        }

        private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            HiddenScrollViewControl Control = Element as HiddenScrollViewControl;

            if(ChildCount > 0)
            {
                GetChildAt(0).HorizontalScrollBarEnabled = Control.IsScrollEnabled;
                GetChildAt(0).VerticalScrollBarEnabled = Control.IsScrollEnabled;
            }
        }
    }
}