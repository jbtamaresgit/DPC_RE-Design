using Xamarin.Forms;

namespace dpc_app.SharedResources.CustomControls
{
    public class CustomTabbedPage : TabbedPage
    {
        public Color SelectedIconColor
        {
            get { return (Color)GetValue(SelectedIconColorProperty);  }
            set { SetValue(SelectedIconColorProperty, value); }
        }

        public static readonly BindableProperty SelectedIconColorProperty = BindableProperty.Create(
                nameof(SelectedIconColorProperty),
                typeof(Color),
                typeof(CustomTabbedPage),
                Color.White);
    }
}
