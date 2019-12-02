using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterMonitor.ViewModels.ViewModels
{
    public class PartyViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string Initials { get; set; }
        public string BgColour { get; set; }
        public string TextColour { get; set; }
        public bool? IsCommons { get; set; }
        public bool? IsLords { get; set; }
        public int? OldDisId { get; set; }
        public bool? HoLMainParty { get; set; }
        public int? HoLOrder { get; set; }
        public bool? HoLIsSpiritualSide { get; set; }
        public int TotalMemberCount { get; set; }
        public int ActiveMemberCount { get; set; }
    }
}
