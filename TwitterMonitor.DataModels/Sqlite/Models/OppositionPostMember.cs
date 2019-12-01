using System;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class OppositionPostMember
    {
        public int Id { get; set; }
        public int OppositionPostId { get; set; }
        public int MemberId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public Member Member { get; set; }
        public OppositionPost OppositionPost { get; set; }
    }
}
