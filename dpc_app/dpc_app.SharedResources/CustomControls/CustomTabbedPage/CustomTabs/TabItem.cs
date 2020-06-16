using Xamarin.Forms;

namespace dpc_app.SharedResources.CustomControls.CustomTabbedPage.CustomTabs
{
    public abstract class TabItem : ContentView
    {
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
            nameof(IsSelected),
            typeof(bool),
            typeof(TabTextItem),
            false);

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly BindableProperty SelectedTabColorProperty = BindableProperty.Create(
            nameof(SelectedTabColor),
            typeof(Color),
            typeof(TabTextItem));

        public Color SelectedTabColor
        {
            get { return (Color)GetValue(SelectedTabColorProperty); }
            set { SetValue(SelectedTabColorProperty, value); }
        }

        public bool IsSelectable { get; set; } = true;
    }
}
