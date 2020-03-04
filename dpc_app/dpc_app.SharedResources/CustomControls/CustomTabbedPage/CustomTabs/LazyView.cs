using System;
using Xamarin.Forms;

namespace dpc_app.SharedResources.CustomControls.CustomTabbedPage.CustomTabs
{
    public interface ILazyView
    {
        View Content { get; set; }
        Color AccentColor { get; set; }
        bool IsLoaded { get; }
        void LoadView();
    }

    public abstract class LazyViewC : ContentView, ILazyView, IDisposable, IAnimatableReveal
    {
        public static readonly BindableProperty AccentColorProperty = BindableProperty.Create(
            nameof(AccentColor),
            typeof(Color),
            typeof(ILazyView),
            Color.Accent,
            propertyChanged: AccentColorPropertyChanged);

        private static void AccentColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ILazyView lazyView = (ILazyView)bindable;
            if(lazyView.Content is ActivityIndicator activityIndicator)
            {
                activityIndicator.Color = (Color)newValue;
            }
        }

        public Color AccentColor
        {
            get { return (Color)GetValue(AccentColorProperty); }
            set { SetValue(AccentColorProperty, value); }
        }

        public static readonly BindableProperty UseActivityIndicatorProperty = BindableProperty.Create(
            nameof(UseActivityIndicator),
            typeof(bool),
            typeof(ILazyView),
            false,
            propertyChanged: UseActivityIndicatorPropertyChanged);

        private static void UseActivityIndicatorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ILazyView lazyView = (ILazyView)bindable;
            bool UseActivityIndicator = (bool)newValue;

            if (UseActivityIndicator)
            {
                lazyView.Content = new ActivityIndicator
                {
                    Color = lazyView.AccentColor,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    IsRunning = true
                };
            }
        }

        public bool UseActivityIndicator
        {
            get { return (bool)GetValue(UseActivityIndicatorProperty); }
            set { SetValue(UseActivityIndicatorProperty, value); }
        }


        public static readonly BindableProperty AnimateProperty = BindableProperty.Create(
            nameof(Animate),
            typeof(bool),
            typeof(ILazyView),
            false);

        public bool Animate
        {
            get { return (bool)GetValue(AnimateProperty); }
            set { SetValue(AnimateProperty, value); }
        }

        public bool IsLoaded { get; protected set; }

        public abstract void LoadView();

        public void Dispose()
        {
            if(Content is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        protected override void OnBindingContextChanged()
        {
            if(Content != null && !(Content is ActivityIndicator))
            {
                Content.BindingContext = BindingContext;
            }
        }
    }

    public class LazyView<TView> : LazyViewC where TView : View, new()
    {
        public override void LoadView()
        {
            IsLoaded = true;
            View view = new TView { BindingContext = BindingContext };
            Content = view;
        }
    }
}
