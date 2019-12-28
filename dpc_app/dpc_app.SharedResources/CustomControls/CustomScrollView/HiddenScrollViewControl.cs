using Xamarin.Forms;

namespace dpc_app.SharedResources.CustomControls.CustomScrollView
{
    public class HiddenScrollViewControl : ScrollView
    {
        public static readonly BindableProperty IsScrollEnabledProperty = BindableProperty.Create(
           nameof(IsScrollEnabled), typeof(bool), typeof(HiddenScrollViewControl), true);

        public bool IsScrollEnabled
        {
            get { return (bool)GetValue(IsScrollEnabledProperty); }
            set { SetValue(IsScrollEnabledProperty, value); }
        }

        public static readonly BindableProperty IsScrollVisibleProperty = BindableProperty.Create(
           nameof(IsScrollVisible), typeof(bool), typeof(HiddenScrollViewControl), true);

        public bool IsScrollVisible
        {
            get { return (bool)GetValue(IsScrollVisibleProperty); }
            set { SetValue(IsScrollVisibleProperty, value); }
        }
    }
}
