using System;
using System.Collections.Generic;
using System.Text;

namespace Roster.Models
{
    public class RosterUpdateModel
    {
        public string PlayerImageSrc { get; set; }
        public string TeamImageSrc { get; set; }
        public string Announcement { get; set; }
        public string DateReleased { get; set; }
    }
}
