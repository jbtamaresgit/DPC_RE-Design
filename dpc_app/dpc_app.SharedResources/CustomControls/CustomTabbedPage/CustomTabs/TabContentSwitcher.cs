using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace dpc_app.SharedResources.CustomControls.CustomTabbedPage.CustomTabs
{
    public class TabContentSwitcher : Grid, IDisposable
    {

        public bool Animate { get; set; } = true;

        private View _activeView;

        public TabContentSwitcher()
        {
            RowSpacing = 0;
            ColumnSpacing = 0;
        }

        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
            nameof(SelectedIndex),
            typeof(int),
            typeof(TabContentSwitcher),
            defaultValue: -1,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: SelectedIndexPropertyChanged);

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        protected override void OnAdded(View view)
        {
            try
            {
                base.OnAdded(view);
                HideView(view);
            }
            catch(Exception e)
            {

            }    
        }

        private static void SelectedIndexPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            TabContentSwitcher switcher = (TabContentSwitcher)bindable;
            switcher.UpdateSelectedView((int)newValue);
        }

        private void UpdateSelectedView(int SelectedIndex)
        {
            if(SelectedIndex < 0)
            {
                return;
            }

            View previousView = null;
            View newView = null;

            for(int index = 0; index < Children.Count; index++)
            {
                View view = Children[index];

                if (view.IsVisible)
                {
                    previousView = view;
                }

                if (index.Equals(SelectedIndex))
                {
                    newView = view;
                }
            }

            if (previousView != newView)
            {
                if(previousView != null && previousView.IsVisible)
                {
                    HideView(previousView);
                }

                if(newView != null && !newView.IsVisible)
                {
                    ShowView(newView);
                }
            }

        }

        private void ShowView(View newView)
        {
            ILazyView lazyView = newView as ILazyView;

            if (lazyView != null)
            {
                if (!lazyView.IsLoaded)
                {
                    lazyView.LoadView();
                }
            }

            newView.IsVisible = true;

            if (Animate && newView is IAnimatableReveal animatable && animatable.Animate && newView.Opacity.Equals(0))
            {
                View presentView = newView;

                Task.Run(
                    async () =>
                    {
                        Task fadeTask = presentView.FadeTo(1, 500);
                        Task translateTask = presentView.TranslateTo(0, 0, 250, Easing.CubicOut);

                        await Task.WhenAll(fadeTask, translateTask);

                        presentView.TranslationY = 0;
                        presentView.Opacity = 1;
                    });
            }

            if (lazyView != null)
            {
                newView = lazyView.Content;
            }

            _activeView = newView;
        }

        private void HideView(View previousView)
        {
            previousView.IsVisible = false;

            if (Animate && previousView is IAnimatableReveal animatable && animatable.Animate)
            {
                previousView.TranslationY = -200;
                previousView.Opacity = 0;
            }

            if(previousView is ILazyView lazyView)
            {
                previousView = lazyView.Content;
            }

            if (_activeView.Equals(previousView))
            {
                _activeView = null;
            }

        }

        public void Dispose()
        {
            foreach(View child in Children)
            {
                if(child is IDisposable disposableView)
                {
                    disposableView.Dispose();
                }
            }
        }
    }
}
