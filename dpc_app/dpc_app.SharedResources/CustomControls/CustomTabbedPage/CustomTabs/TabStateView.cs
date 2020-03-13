using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace dpc_app.SharedResources.CustomControls.CustomTabbedPage.CustomTabs
{
    [ContentProperty("TabStateContent")]
    public class TabStateView : ContentView
    {

        private readonly Grid _grid;
        private readonly List<TabItem> _selectableTabs = new List<TabItem>();

        private readonly int _childRow = 0;

        private ScrollView _scrollView;
        //private BoxView _contentBackgroundView;
        //private RowDefinition _shadowRowDefinition;
        private ColumnDefinition _lastFillingColumn;
        public event EventHandler<SelectedPositionChangedEventArgs> SelectedTabIndexChanged;

        public bool ShowScrollbar { get; set; }
        public ICommand TabItemTappedCommand { get; set; }

        // Tabs


        public static readonly BindableProperty TabsProperty = BindableProperty.Create(
            nameof(Tabs),
            typeof(ObservableCollection<TabItem>),
            typeof(TabStateView),
            defaultValueCreator: _ => new ObservableCollection<TabItem>());

        public ObservableCollection<TabItem> Tabs
        {
            get { return (ObservableCollection<TabItem>)GetValue(TabsProperty); }
            set { SetValue(TabsProperty, value); }
        }

        public static readonly BindableProperty TabTypeProperty = BindableProperty.Create(
            nameof(TabType),
            typeof(TabTypeEnum),
            typeof(TabStateView),
            defaultValue: TabTypeEnum.Fixed,
            defaultBindingMode: BindingMode.OneWayToSource);

        public TabTypeEnum TabType
        {
            get { return (TabTypeEnum)GetValue(TabTypeProperty); }
            set { SetValue(TabTypeProperty, value); }
        }

        private void UpdateTabType()
        {
            if (TabType.Equals(TabTypeEnum.Scrollable))
            {
                base.Content = _scrollView
                    ?? (_scrollView = new ScrollView()
                    {
                        Orientation = ScrollOrientation.Horizontal,
                        HorizontalScrollBarVisibility = ShowScrollbar ? ScrollBarVisibility.Always : ScrollBarVisibility.Never
                    });

                _scrollView.Content = _grid;
                foreach(ColumnDefinition definition in _grid.ColumnDefinitions)
                {
                    definition.Width = GridLength.Auto;
                }
            }
            else
            {
                base.Content = _grid;
                foreach (ColumnDefinition definition in _grid.ColumnDefinitions)
                {
                    definition.Width = GridLength.Star;
                }
            }
        }

        private void TabsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach(var tab in e.NewItems)
                    {
                        OnChildAdded((TabItem)tab);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var tab in e.OldItems)
                    {
                        OnChildRemoved((TabItem)tab);
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        private void OnChildAdded(TabItem tabItem)
        {
            _grid.Children.Add(tabItem);

            _grid.ColumnDefinitions.Add(new ColumnDefinition { Width = TabType == TabTypeEnum.Fixed ? GridLength.Star : GridLength.Auto });

            if (TabType == TabTypeEnum.Scrollable)
            {
                if (Tabs.Count == 1)
                {
                    _lastFillingColumn = new ColumnDefinition { Width = GridLength.Star };
                    _grid.ColumnDefinitions.Add(_lastFillingColumn);
                }
                else
                {
                    _grid.ColumnDefinitions.Remove(_lastFillingColumn);
                    _grid.ColumnDefinitions.Add(_lastFillingColumn);
                }
            }

            Grid.SetColumn(tabItem, Tabs.Count - 1);
            Grid.SetRow(tabItem, _childRow);

            if (tabItem.IsSelectable)
            {
                AddTapCommand(tabItem);
                _selectableTabs.Add(tabItem);
            }

            if (TabType == TabTypeEnum.Fixed)
            {
                tabItem.PropertyChanged += OnTabItemPropertyChanged;
                UpdateTabVisibility(tabItem);
            }

            UpdateSelectedIndex(SelectedIndex);
        }

        private void AddTapCommand(TabItem tabItem)
        {
            tabItem.GestureRecognizers.Add(
                new TapGestureRecognizer() { Command = TabItemTappedCommand, CommandParameter = tabItem });
        }

        private void OnChildRemoved(TabItem tabItem)
        {
            if (_grid.ColumnDefinitions.Count == 0)
            {
                return;
            }

            if (TabType == TabTypeEnum.Scrollable)
            {
                if (Tabs.Count == 0)
                {
                    _grid.ColumnDefinitions.Remove(_lastFillingColumn);
                }
            }

            if (tabItem.IsSelectable)
            {
                _selectableTabs.Remove(tabItem);
            }

            _grid.Children.Remove(tabItem);

            _grid.ColumnDefinitions.RemoveAt(_grid.ColumnDefinitions.Count - 1);

            tabItem.PropertyChanged -= OnTabItemPropertyChanged;

            UpdateSelectedIndex(SelectedIndex);
        }

        private void OnTabItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            TabItem tabItem = (TabItem)sender;
            if (e.PropertyName == nameof(TabItem.IsVisible))
            {
                UpdateTabVisibility(tabItem);
            }
        }

        private void UpdateTabVisibility(TabItem tabItem)
        {
            int columnIndex = Grid.GetColumn(tabItem);
            var columnDefinition = _grid.ColumnDefinitions[columnIndex];
            columnDefinition.Width = tabItem.IsVisible ? GridLength.Star : 0;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(TabType):
                    UpdateTabType();
                    break;
                case nameof(TabBackgroundColor):
                    UpdateBackgroundColor();
                    break;
                case nameof(Tabs):
                    throw new NotSupportedException("Updating Tabs collection reference is not supported");
            }
        }


        // SelectedIndex

        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
            nameof(SelectedIndex),
            typeof(int),
            typeof(TabStateView),
            defaultValue: -1,
            propertyChanged: SelectedIndexPropertyChanged);

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        private static void SelectedIndexPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            TabStateView stateView = (TabStateView)bindable;

            if((int)newValue < 0)
            {
                return;
            }

            stateView.UpdateSelectedIndex((int)newValue);
            stateView.RaiseSelectedTabIndexChanged(new SelectedPositionChangedEventArgs((int)newValue));
        }

        private void RaiseSelectedTabIndexChanged(SelectedPositionChangedEventArgs selectedPositionChangedEventArgs)
        {
            SelectedTabIndexChanged?.Invoke(this, selectedPositionChangedEventArgs);
        }

        private void UpdateSelectedIndex(int selectedIndex)
        {
            if (_selectableTabs.Count.Equals(0))
            {
                selectedIndex = 0;
            }

            if(selectedIndex > _selectableTabs.Count)
            {
                selectedIndex = _selectableTabs.Count - 1;
            }

            for(int index = 0; index < _selectableTabs.Count; index++)
            {
                _selectableTabs[index].IsSelected = selectedIndex == index;
            }

            SelectedIndex = selectedIndex;
        }


        //Background Color

        public static readonly BindableProperty TabBackgroundColorProperty = BindableProperty.Create(
           nameof(TabBackgroundColor),
           typeof(Color),
           typeof(TabStateView),
           Color.Transparent);

        public Color TabBackgroundColor
        {
            get { return (Color)GetValue(TabBackgroundColorProperty); }
            set { SetValue(TabBackgroundColorProperty, value); }
        }

        public new View Content
        {
            get => base.Content;
            set => throw new NotSupportedException(
                "Only allowed to add TabItem to the TabStateView through tabs property");
        }

        private void UpdateBackgroundColor()
        {

            _grid.BackgroundColor = Color.Transparent;
            //_contentBackgroundView.BackgroundColor = Color.Black;
        }

        //Tab Item Tapped

        private void OnTabItemTapped(object tappedItem)
        {
            int selectedIndex = _selectableTabs.IndexOf((TabItem)tappedItem);

            UpdateSelectedIndex(selectedIndex);
            RaiseSelectedTabIndexChanged(new SelectedPositionChangedEventArgs(selectedIndex));
        }


        public TabStateView()
        {

            TabItemTappedCommand = new Command(OnTabItemTapped);
            Tabs.CollectionChanged += TabsOnCollectionChanged;
            _grid = new Grid
            {
                RowSpacing = 0,
                ColumnSpacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Fill
            };

            UpdateTabType();
        }


    }
}
