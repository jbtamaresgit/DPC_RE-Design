namespace DPCStandings.Models
{
    public class DPCStandingsTeamContent
    {
        public DPCStandingsTeamContent()
        {

        }

        public DPCStandingsTeamContent(DPCStandingsTeamContent content , int rank)
        {
            Rank = rank;
            IconStatus = content.IconStatus;
            TeamImageSrc = content.TeamImageSrc;
            TeamName = content.TeamName;
            TeamStats = content.TeamStats;
            TeamGainedPts = content.TeamGainedPts;
            TeamTotalPts = content.TeamTotalPts;
        }

        public string IconStatus { get; set; }
        public int Rank { get; set; }
        public string TeamImageSrc { get; set; }
        public string TeamName { get; set; }
        public string TeamStats { get; set; }
        public string TeamGainedPts { get; set; }
        public string TeamTotalPts { get; set; }
    }
}
