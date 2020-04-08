using dpc_app.Common.IconFonts;
using DPCStandings.Models;
using MvvmHelpers;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Linq;

namespace DPCStandings.ViewModels
{
    public class DPCStandingsOverviewViewModel : BaseViewModel
    {
        public DPCStandingsOverviewViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public string ImageSrc { get { return "https://i.imgur.com/NiZZ32z.jpg"; } }

        public string PageTitle { get { return "DPC Standings"; } }

        private ObservableRangeCollection<DPCStandingsTeamContent> _DPCStandings;
        public ObservableRangeCollection<DPCStandingsTeamContent> DPCStandings
        {
            get { return _DPCStandings; }
            set { SetProperty(ref _DPCStandings, value); }
        }

        private DelegateCommand _NavigateBackCommand;
        public DelegateCommand NavigateBackCommand =>
            _NavigateBackCommand ?? (_NavigateBackCommand = new DelegateCommand(ExecuteNavigateBackCommand));

        void ExecuteNavigateBackCommand()
        {
            base.GoBackAsync();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            List<DPCStandingsTeamContent> ContentWithoutRank = new List<DPCStandingsTeamContent>()
            {
                new DPCStandingsTeamContent
                {
                    IconStatus = LineAwesomeFonts.Minus,
                    TeamImageSrc = "https://liquipedia.net/commons/images/a/a6/TNC_Predator_logo_201907.png",
                    TeamName = "TNC Predator",
                    TeamStats = "1/1/1",
                    TeamGainedPts = "+10",
                    TeamTotalPts = "4613"
                },
                new DPCStandingsTeamContent
                {
                    IconStatus = LineAwesomeFonts.Minus,
                    TeamImageSrc = "https://liquipedia.net/commons/images/a/a6/TNC_Predator_logo_201907.png",
                    TeamName = "TNC Predator",
                    TeamStats = "1/1/1",
                    TeamGainedPts = "+10",
                    TeamTotalPts = "4111"
                },
                new DPCStandingsTeamContent
                {
                    IconStatus = LineAwesomeFonts.Minus,
                    TeamImageSrc = "https://liquipedia.net/commons/images/a/a6/TNC_Predator_logo_201907.png",
                    TeamName = "TNC Predator",
                    TeamStats = "1/1/1",
                    TeamGainedPts = "+10",
                    TeamTotalPts = "4222"
                }
            };

            List<DPCStandingsTeamContent> ContentWithRank = ContentWithoutRank.OrderBy(x => x.TeamTotalPts).Select((x, y) => new DPCStandingsTeamContent(x, y + 1)).ToList();
            DPCStandings = new ObservableRangeCollection<DPCStandingsTeamContent>(ContentWithRank);
        }
    }
}
