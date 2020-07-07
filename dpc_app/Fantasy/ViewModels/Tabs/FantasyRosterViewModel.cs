using dpc_app.Common.Helpers.Collections;
using Fantasy.Models;
using MvvmHelpers;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fantasy.ViewModels.Tabs
{
    public class FantasyRosterViewModel : BaseViewModel, IInitialize
    {
        public FantasyRosterViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private List<FantasyRosterModel> RosterContainer;

        private ObservableRangeCollection<GroupingHelper<string, FantasyRosterModel>> _RosterList;
        public ObservableRangeCollection<GroupingHelper<string, FantasyRosterModel>> RosterList
        {
            get { return _RosterList; }
            set { SetProperty(ref _RosterList, value); }
        }

        public void Initialize(INavigationParameters parameters)
        {
            InitializeCollection();
        }

        private void InitializeCollection()
        {
            RosterContainer = new List<FantasyRosterModel>()
            {
                new FantasyRosterModel
                {
                    PlayerID = 1,
                    PlayerImgSrc = "https://liquipedia.net/commons/images/a/a6/TNC_Predator_logo_201907.png",
                    PlayerName = "Armel",
                    PlayerTeam = "TNC Predator",
                    PlayerRole = "CORE",
                    PlayerRoleCode = PlayerRoleEnum.pos2,
                    HasSelected = true,
                    IsLocked = false,
                },
                new FantasyRosterModel
                {
                    PlayerID = 1,
                    PlayerImgSrc = "https://liquipedia.net/commons/images/a/a6/TNC_Predator_logo_201907.png",
                    PlayerName = "Armel",
                    PlayerTeam = "TNC Predator",
                    PlayerRole = "CORE",
                    PlayerRoleCode = PlayerRoleEnum.pos2,
                    HasSelected = true,
                    IsLocked = false,
                },
                new FantasyRosterModel
                {
                    PlayerRole = "CORE",
                    HasSelected = false,
                    IsLocked = false
                }
            };

            List<GroupingHelper<string, FantasyRosterModel>> sorted = RosterContainer.GroupBy(x => x.PlayerRole)
                    .Select(x => new GroupingHelper<string, FantasyRosterModel>(x.Key, x))
                    .ToList();

            RosterList = new ObservableRangeCollection<GroupingHelper<string, FantasyRosterModel>>();
            RosterList.ReplaceRange(sorted);

        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }


    }
}
