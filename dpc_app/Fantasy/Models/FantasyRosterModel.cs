namespace Fantasy.Models
{
    public class FantasyRosterModel
    {
        public int PlayerID { get; set; }
        public PlayerRoleEnum? PlayerRoleCode { get; set; }
        public string PlayerRole { get; set; }
        public string PlayerImgSrc { get; set; }
        public string PlayerName { get; set; }
        public string PlayerTeam { get; set; }
        public bool? IsLocked { get; set; }
        public bool HasSelected { get; set; }
    }

    public enum PlayerRoleEnum
    {
        pos1 = 1,
        pos2 = 2,
        pos3 = 3,
        pos4 = 4,
        pos5 = 5
    }
}
