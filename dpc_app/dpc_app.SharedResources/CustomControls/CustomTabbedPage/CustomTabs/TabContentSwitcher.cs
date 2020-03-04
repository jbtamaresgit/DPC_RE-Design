using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace dpc_app.SharedResources.CustomControls.CustomTabbedPage.CustomTabs
{
    public class TabContentSwitcher : Grid, IDisposable
    {
        public TabContentSwitcher()
        {
            RowSpacing = 0;
            ColumnSpacing = 0;
        }

        public bool Animate { get; set; } = true;

        private View _activeView;

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

        private static void SelectedIndexPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            TabContentSwitcher switcher = (TabContentSwitcher)bindable;
            switcher.UpdateSelectedView((int)newValue);
        }

        private void UpdateSelectedView(int SelectedNewIndex)
        {
            if(SelectedNewIndex < 0)
            {
                return;
            }

            View previousView = null;
            int previousViewIndex = -1;

            View newView = null;

            for(int index = 0; index < Children.Count; index++)
            {
                View view = Children[index];

                if (view.IsVisible)
                {
                    previousView = view;
                    previousViewIndex = index;
                }

                if (index.Equals(SelectedNewIndex))
                {
                    newView = view;
                }
            }

            if (!previousView.Equals(newView))
            {
                if(!previousView.Equals(null) && previousView.IsVisible)
                {
                    HideView(previousView, previousViewIndex);
                }

                if(!newView.Equals(null) && !newView.IsVisible)
                {
                    ShowView(newView, SelectedNewIndex);
                }
            }

        }

        private void ShowView(View newView, int selectedNewIndex)
        {
            ILazyView lazyView = newView as ILazyView;

            if (!lazyView.Equals(null))
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

            if (!lazyView.Equals(null))
            {
                newView = lazyView.Content;
            }

            _activeView = newView;
        }

        private void HideView(View previousView, int previousViewIndex)
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
            
        }
    }
}
