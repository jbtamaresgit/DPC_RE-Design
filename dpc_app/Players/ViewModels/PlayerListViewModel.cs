using dpc_app.Common.Extensions;
using MvvmHelpers;
using Players.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Players.ViewModels
{
    public class PlayerListViewModel : BaseViewModel
    {
        public PlayerListViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public string ImageSrc { get { return "https://i.axs.com/2019/11/67184-image_5dd4889332d17.jpg"; } }

        public string PageTitle { get { return "Players"; } }

        private string _SearchItem;
        public string SearchItem
        {
            get { return _SearchItem; }
            set { SetProperty(ref _SearchItem, value); }
        }

        private ObservableCollection<Point> Points;
        private List<PlayerModel> container;

        private ObservableRangeCollection<PlayerModel> _Players;
        public ObservableRangeCollection<PlayerModel> Players
        {
            get { return _Players; }
            set { SetProperty(ref _Players, value); }
        }

        private DelegateCommand<PlayerModel> _IsFavoriteCommand;
        public DelegateCommand<PlayerModel> IsFavoriteCommand =>
            _IsFavoriteCommand ?? (_IsFavoriteCommand = new DelegateCommand<PlayerModel>(ExecuteFavoriteCommand));

        void ExecuteFavoriteCommand(PlayerModel item)
        {
            item.IsFavorite = !item.IsFavorite;
            item.FavoriteIconColor = item.IsFavorite ?  Color.FromHex("#D10014") : Color.White;
        }

        private DelegateCommand<string> _SearchCommand;
        public DelegateCommand<string> SearchCommand =>
            _SearchCommand ?? (_SearchCommand = new DelegateCommand<string>(ExecuteSearchCommand));

        void ExecuteSearchCommand(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                Players.ReplaceRange(container);
            }
            else
            {
                Players.ReplaceRange(container
                                     .Where(o => StringExtensions.Contains(o.PlayerName, searchString, StringComparison.OrdinalIgnoreCase))
                                     .ToList());
            }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Points = new ObservableCollection<Point>
            {
                new Point(5, 5),
                new Point(50, 5),
                new Point(50, 50),
                new Point(27, 70),
                new Point(5, 50)
            };

            container = new List<PlayerModel>()
            {
                new PlayerModel
                {
                    PlayerID = 1,
                    PlayerImgSource = "https://ggscore.com/media/logo/p10767.png",
                    PlayerName = "Armel",
                    TeamName = "  TNC Predator",
                    Country = "  Philippines",
                    Role = "  Position Two",
                    IsFavorite = true,
                    FavoriteIconColor = Color.White,
                    IsFavoriteCommand = IsFavoriteCommand,
                    Points = Points,
                    TeamImgSource = "https://liquipedia.net/commons/images/a/a6/TNC_Predator_logo_201907.png"
                },
                new PlayerModel
                {
                    PlayerID = 2,
                    PlayerImgSource = "https://ggscore.com/media/logo/p10767.png",
                    PlayerName = "Armel Number 2",
                    TeamName = "  TNC Predator",
                    Country = "  Philippines",
                    Role = "  Position Two",
                    IsFavorite = true,
                    FavoriteIconColor = Color.White,
                    IsFavoriteCommand = IsFavoriteCommand,
                    Points = Points,
                    TeamImgSource = "https://liquipedia.net/commons/images/a/a6/TNC_Predator_logo_201907.png"
                }
            };

            Players = new ObservableRangeCollection<PlayerModel>(container);

        }
    }
}
