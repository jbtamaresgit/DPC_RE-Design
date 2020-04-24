using dpc_app.Common.Helpers.Extensions;
using MvvmHelpers;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Teams.Models;

namespace Teams.ViewModels
{
    public class TeamsViewModel : BaseViewModel
    {
        public TeamsViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        public string ImageSrc { get { return "https://www.jakpost.travel/wimages/large/127-1273501_epic-battle-desktop-wallpaper-dota-2-wallpaper-chaos.jpg"; } }

        public string PageTitle { get { return "Teams"; } }

        private List<TeamModel> Container { get; set; }

        private string _SearchItem;
        public string SearchItem
        {
            get { return _SearchItem; }
            set { SetProperty(ref _SearchItem, value); }
        }

        private ObservableRangeCollection<TeamModel> _Teams;
        public ObservableRangeCollection<TeamModel> Teams
        {
            get { return _Teams; }
            set { SetProperty(ref _Teams, value); }
        }

        private DelegateCommand<TeamModel> _FavoriteCommand;
        public DelegateCommand<TeamModel> FavoriteCommand =>
            _FavoriteCommand ?? (_FavoriteCommand = new DelegateCommand<TeamModel>(ExecuteFavoriteCommand));

        void ExecuteFavoriteCommand(TeamModel item)
        {
            item.IsFavorite = !item.IsFavorite;
        }

        private DelegateCommand<string> _SearchCommand;
        public DelegateCommand<string> SearchCommand =>
            _SearchCommand ?? (_SearchCommand = new DelegateCommand<string>(ExecuteSearchCommand));

        void ExecuteSearchCommand(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                Teams.ReplaceRange(Container);
            }
            else
            {
                Teams.ReplaceRange(Container
                                     .Where(o => StringExtensions.Contains(o.TeamName, searchString, StringComparison.OrdinalIgnoreCase))
                                     .ToList());
            }
        }

        private DelegateCommand<TeamModel> _SelectTeamCommand;
        public DelegateCommand<TeamModel> SelectTeamCommand =>
            _SelectTeamCommand ?? (_SelectTeamCommand = new DelegateCommand<TeamModel>(ExecuteSelectTeamCommand));

        void ExecuteSelectTeamCommand(TeamModel Team)
        {

        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Container = new List<TeamModel>()
            {
                new TeamModel
                {
                    TeamID = 1,
                    IsFavorite = false,
                    TeamImgSrc = "https://liquipedia.net/commons/images/a/a6/TNC_Predator_logo_201907.png",
                    TeamName = "TNC Predator",
                    LatestAchievement = " 1ST Major Winner",
                    TeamLocation = " Philippines",
                    PlayerImgSrc_1 = "https://ggscore.com/media/logo/p10767.png",
                    PlayerImgSrc_2 = "https://ggscore.com/media/logo/p10765.png",
                    PlayerImgSrc_3 = "https://ggscore.com/media/logo/p10760.png",
                    PlayerImgSrc_4 = "https://i.dailymail.co.uk/i/newpix/2018/03/11/15/4A172D3E00000578-0-image-a-17_1520783282576.jpg",
                    PlayerImgSrc_5 = "https://cdn0.gamesports.net/edb_player_images/2000/2627.png?1535550914",
                    FavoriteCommand = FavoriteCommand
                }
            };

            Teams = new ObservableRangeCollection<TeamModel>(Container);
        }
    }
}
