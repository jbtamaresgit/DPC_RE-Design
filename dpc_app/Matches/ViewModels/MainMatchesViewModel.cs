using dpc_app.Common.Helpers.Collections;
using Matches.Models;
using MvvmHelpers;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Linq;

namespace Matches.ViewModels
{
    public class MainMatchesViewModel : BaseViewModel
    {
        public MainMatchesViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private int _SelectedViewModelIndex;
        public int SelectedViewModelIndex
        {
            get { return _SelectedViewModelIndex; }
            set { SetProperty(ref _SelectedViewModelIndex, value); }
        }

        private ObservableRangeCollection<GroupingHelper<string, MatchesModel>> _Matches;
        public ObservableRangeCollection<GroupingHelper<string, MatchesModel>> Matches
        {
            get { return _Matches; }
            set { SetProperty(ref _Matches, value); }
        }

        private DelegateCommand _NavigateBackCommand;
        public DelegateCommand NavigateBackCommand =>
            _NavigateBackCommand ?? (_NavigateBackCommand = new DelegateCommand(ExecuteNavigateBackCommand));

        void ExecuteNavigateBackCommand()
        {
            GoBackAsync();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            List<MatchesModel> matches = new List<MatchesModel>
            {
                new MatchesModel
                {
                    TeamA_ImgSource = "https://liquipedia.net/commons/images/thumb/8/89/FlyToMoon_Logo.png/600px-FlyToMoon_Logo.png",
                    TeamA_TeamName = "FlyToMoon",
                    TeamB_ImgSource = "https://upload.wikimedia.org/wikipedia/en/thumb/a/ac/NaVi_logo.svg/1200px-NaVi_logo.svg.png",
                    TeamB_TeamName = "Natus Vincere",
                    GameRound = "Game 1",
                    GameRoundScore = "15 : 31",
                    GameTime =  "32:46",
                    IsLive = true,
                    GroupTitle = "LIVE"
                },
                new MatchesModel
                {
                    TeamA_ImgSource = "https://liquipedia.net/commons/images/thumb/8/89/FlyToMoon_Logo.png/600px-FlyToMoon_Logo.png",
                    TeamA_TeamName = "FlyToMoon",
                    TeamB_ImgSource = "https://upload.wikimedia.org/wikipedia/en/thumb/a/ac/NaVi_logo.svg/1200px-NaVi_logo.svg.png",
                    TeamB_TeamName = "Natus Vincere",
                    GameRound = "Game 1",
                    GameRoundScore = "15 : 31",
                    GameTime =  "32:46",
                    IsLive = false,
                    GroupTitle = "EARLIER TODAY"
                },
            };

            List<GroupingHelper<string, MatchesModel>> sort = matches.OrderByDescending(x => x.IsLive)
                .GroupBy(x => x.GroupTitle)
                .Select(x => new GroupingHelper<string, MatchesModel>(x.Key, x))
                .ToList();


            Matches = new ObservableRangeCollection<GroupingHelper<string, MatchesModel>>(sort);
        }
    }
}
