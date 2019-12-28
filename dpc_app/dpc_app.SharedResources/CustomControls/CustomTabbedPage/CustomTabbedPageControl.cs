using Xamarin.Forms;

namespace dpc_app.SharedResources.CustomControls.CustomTabbedPage
{
    public class CustomTabbedPageControl : TabbedPage
    {
        public Color SelectedIconColor
        {
            get { return (Color)GetValue(SelectedIconColorProperty);  }
            set { SetValue(SelectedIconColorProperty, value); }
        }

        public static readonly BindableProperty SelectedIconColorProperty = BindableProperty.Create(
                nameof(SelectedIconColor),
                typeof(Color),
                typeof(CustomTabbedPageControl),
                Color.White);

        public Color UnSelectedIconColor
        {
            get { return (Color)GetValue(UnSelectedIconColorProperty); }
            set { SetValue(UnSelectedIconColorProperty, value); }
        }

        public static readonly BindableProperty UnSelectedIconColorProperty = BindableProperty.Create(
                nameof(UnSelectedIconColor),
                typeof(Color),
                typeof(CustomTabbedPageControl),
                Color.White);

        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty SelectedTextColorProperty = BindableProperty.Create(
                nameof(SelectedTextColorProperty),
                typeof(Color),
                typeof(CustomTabbedPageControl),
                Color.White);

        public Color UnSelectedTextColor
        {
            get { return (Color)GetValue(UnSelectedTextColorProperty); }
            set { SetValue(UnSelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty UnSelectedTextColorProperty = BindableProperty.Create(
                nameof(UnSelectedTextColor),
                typeof(Color),
                typeof(CustomTabbedPageControl),
                Color.White);
    }
}
