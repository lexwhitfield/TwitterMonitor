using System;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class ConstituencyMembers
    {
        public int Id { get; set; }
        public int ConstituencyId { get; set; }
        public int MemberId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ElectionId { get; set; }
        public string EndReason { get; set; }
        public string EntryType { get; set; }



        public Constituency Constituency { get; set; }
        public Member Member { get; set; }
        public Election Election { get; set; }
    }
}
