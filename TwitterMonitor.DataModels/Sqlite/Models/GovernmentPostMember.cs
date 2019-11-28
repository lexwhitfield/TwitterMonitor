using System;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class GovernmentPostMember
    {
        public int Id { get; set; }
        public int GovernmentPostId { get; set; }
        public int MemberId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public Member Member { get; set; }
        public GovernmentPost GovernmentPost { get; set; }
    }
}
