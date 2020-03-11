using dpc_app.Common.IconFonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dpc_app.SharedResources.CustomControls.CustomButton
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconButtonControl : ContentView
    {
        public IconButtonControl()
        {
            InitializeComponent();
        }

        public static BindableProperty IsButtonEnabledProperty =
            BindableProperty.Create(
                nameof(IsButtonEnabled),
                typeof(bool),
                typeof(IconButtonControl),
                true,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    IconButtonControl ctrl = (IconButtonControl)bindable;
                    ctrl.IconButton.IsEnabled = (bool)newValue;

                    if (ctrl.IconButton.IsEnabled)
                    {
                        ctrl.IconButton.BackgroundColor = ctrl.IconBackgroundColor;
                        ctrl.IconButton.TextColor = ctrl.IconColor;
                        ctrl.IconButton.BorderColor = ctrl.ButtonBorderColor;
                    }
                }
            );

        public bool IsButtonEnabled
        {
            get { return Convert.ToBoolean(GetValue(IsButtonEnabledProperty)); }
            set { SetValue(IsButtonEnabledProperty, value); }
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(IconButtonControl), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(Button), null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static BindableProperty ButtonMarginProperty =
            BindableProperty.Create(
                nameof(ButtonMargin),
                typeof(Thickness),
                typeof(IconButtonControl),
                new Thickness(0),
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    IconButtonControl ctrl = (IconButtonControl)bindable;
                    Thickness val = (Thickness)newValue;
                    ctrl.IconButton.Margin = val;
                }
            );

        public Thickness ButtonMargin
        {
            get { return (Thickness)GetValue(ButtonMarginProperty); }
            set { SetValue(ButtonMarginProperty, value); }
        }

        public static BindableProperty CornerRadiusProperty =
             BindableProperty.Create(
                 nameof(CornerRadius),
                 typeof(int),
                 typeof(IconButtonControl),
                 8,
                 defaultBindingMode: BindingMode.TwoWay,
                 propertyChanged: (bindable, oldValue, newValue) =>
                 {
                     int val = (int)newValue;
                     if (val > 0)
                     {
                         var ctrl = (IconButtonControl)bindable;
                         ctrl.IconButton.CornerRadius = val;
                     }
                 }
             );

        public int CornerRadius
        {
            get { return (int)(GetValue(CornerRadiusProperty)); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static BindableProperty IconSizeProperty =
             BindableProperty.Create(
                 nameof(IconSize),
                 typeof(double),
                 typeof(IconButtonControl),
                 36.0,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: (bindable, oldValue, newValue) =>
                 {
                     double val = Convert.ToDouble(newValue);
                     if (val > 0)
                     {
                         IconButtonControl ctrl = (IconButtonControl)bindable;
                         ctrl.IconButton.FontSize = val;
                     }
                 }
             );

        public double ButtonBorderWidth
        {
            get { return (double)(GetValue(ButtonBorderWidthProperty)); }
            set { SetValue(ButtonBorderWidthProperty, value); }
        }

        public static BindableProperty ButtonBorderWidthProperty =
             BindableProperty.Create(
                 nameof(ButtonBorderWidth),
                 typeof(double),
                 typeof(IconButtonControl),
                 1.0,
                 defaultBindingMode: BindingMode.TwoWay,
                 propertyChanged: (bindable, oldValue, newValue) =>
                 {
                     double val = Convert.ToDouble(newValue);
                     if (val > 0)
                     {
                         var ctrl = (IconButtonControl)bindable;
                         ctrl.IconButton.BorderWidth = val;
                     }
                 }
             );

        public Color ButtonBorderColor
        {
            get { return (Color)GetValue(ButtonBorderColorProperty); }
            set { SetValue(ButtonBorderColorProperty, value); }
        }

        public static BindableProperty ButtonBorderColorProperty =
          BindableProperty.Create(
              nameof(ButtonBorderColor),
              typeof(Color),
              typeof(IconButtonControl),
              Color.Black,
              defaultBindingMode: BindingMode.TwoWay,
              propertyChanged: (bindable, oldValue, newValue) =>
              {
                  IconButtonControl ctrl = (IconButtonControl)bindable;
                  ctrl.IconButton.BorderColor = (Color)newValue;
              }
          );

        public double IconSize
        {
            get { return Convert.ToDouble(GetValue(IconSizeProperty)); }
            set { SetValue(IconSizeProperty, value); }
        }

        public static BindableProperty IconColorProperty =
             BindableProperty.Create(
                 nameof(IconColor),
                 typeof(Color),
                 typeof(IconButtonControl),
                 Color.White,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: (bindable, oldValue, newValue) =>
                 {
                     IconButtonControl ctrl = (IconButtonControl)bindable;
                     ctrl.IconButton.TextColor = (Color)newValue;
                 }
             );

        public Color IconColor
        {
            get { return (Color)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

        public static BindableProperty IconBackgroundColorProperty =
          BindableProperty.Create(
              nameof(IconBackgroundColor),
              typeof(Color),
              typeof(IconButtonControl),
              Color.Black,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: (bindable, oldValue, newValue) =>
              {
                  IconButtonControl ctrl = (IconButtonControl)bindable;
                  ctrl.IconButton.BackgroundColor = (Color)newValue;
              }
          );

        public Color IconBackgroundColor
        {
            get { return (Color)GetValue(IconBackgroundColorProperty); }
            set { SetValue(IconBackgroundColorProperty, value); }
        }

        public static BindableProperty IconProperty =
             BindableProperty.Create(
                 nameof(IconProperty),
                 typeof(string),
                 typeof(IconButtonControl),
                 default(string),
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: (bindable, oldValue, newValue) =>
                 {
                     IconButtonControl ctrl = (IconButtonControl)bindable;
                     string val = typeof(LineAwesomeFonts).GetField((string)newValue).GetValue("").ToString();

                     ctrl.IconButton.Text = (string)val;
                 }
             );

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        private void IconButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}