using System;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class PartyMember
    {
        public int Id { get; set; }
        public int? PartyId { get; set; }
        public int? MemberId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public Party Party { get; set; }
        public Member Member { get; set; }
    }
}
