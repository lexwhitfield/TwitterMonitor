using System;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Member
    {
        public int Id { get; set; }
        public int? TitleId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public int ConstituencyId { get; set; }
        public int PartyId { get; set; }
        public long? TwitterId { get; set; }
        public int StartYear { get; set; }
        public int? EndYear { get; set; }
        public bool WhipSuspended { get; set; }

        public Title Title { get; set; }
        public Constituency Constituency { get; set; }
        public Party Party { get; set; }
        public TwitterUser Twitter { get; set; }
    }
}
