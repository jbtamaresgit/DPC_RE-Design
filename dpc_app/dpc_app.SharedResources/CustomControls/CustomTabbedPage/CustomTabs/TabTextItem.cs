using Xamarin.Forms;

namespace dpc_app.SharedResources.CustomControls.CustomTabbedPage.CustomTabs
{
    public abstract class TabTextItem : TabItem
    {
        //public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
        //    nameof(FontFamily),
        //    typeof(string),
        //    typeof(TabTextItem),
        //    null,
        //    BindingMode.OneWay);

        //public string FontFamily
        //{
        //    get { return (string)GetValue(FontFamilyProperty); }
        //    set { SetValue(FontFamilyProperty, value); }
        //}

        public static readonly BindableProperty LabelContentProperty = BindableProperty.Create(
            nameof(LabelContent),
            typeof(string),
            typeof(TabTextItem),
            string.Empty);

        public string LabelContent
        {
            get { return (string)GetValue(LabelContentProperty); }
            set { SetValue(LabelContentProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty = BindableProperty.Create(
            nameof(LabelSize),
            typeof(double),
            typeof(TabTextItem));

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty UnselectedLabelColorProperty = BindableProperty.Create(
            nameof(UnselectedLabelColor),
            typeof(Color),
            typeof(TabTextItem));

        public Color UnselectedLabelColor
        {
            get { return (Color)GetValue(UnselectedLabelColorProperty); }
            set { SetValue(UnselectedLabelColorProperty, value); }
        }
    }
}
