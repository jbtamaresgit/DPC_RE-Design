using Xamarin.Forms;

namespace dpc_app.SharedResources.CustomControls.CustomEntry
{
    public class CustomBorderEntryControl : Entry
    {
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
           nameof(BorderColor), typeof(Color), typeof(CustomBorderEntryControl), Color.Transparent);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }


        public static readonly BindableProperty HasBorderProperty = BindableProperty.Create(
           nameof(HasBorder), typeof(bool), typeof(CustomBorderEntryControl), true);

        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }
    }
}
