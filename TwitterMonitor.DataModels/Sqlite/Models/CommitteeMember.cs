using System;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class CommitteeMember
    {
        public int Id { get; set; }
        public int CommitteeId { get; set; }
        public int MemberId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EndNote { get; set; }
        public bool IsExOfficio { get; set; }
        public bool IsAlternate { get; set; }
        public bool IsCoOpted { get; set; }


        public Committee Committee { get; set; }
        public Member Member { get; set; }
    }
}
