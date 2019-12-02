using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Party
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string Initials { get; set; }
        public string Colour { get; set; }
        public string TextColour { get; set; }
        public bool IsCommons { get; set; }
        public bool IsLords { get; set; }
        public int? OldDisId { get; set; }
        public bool HoLMainParty { get; set; }
        public int? HoLOrder { get; set; }
        public bool HoLIsSpiritualSide { get; set; }

        public ICollection<PartyMember> Members { get; set; }
    }
}
