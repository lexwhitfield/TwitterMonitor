using System;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class ParliamentaryPostMember
    {
        public int Id { get; set; }
        public int ParliamentaryPostId { get; set; }
        public int MemberId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }



        public ParliamentaryPost ParliamentaryPost { get; set; }
        public Member Member { get; set; }
    }
}
