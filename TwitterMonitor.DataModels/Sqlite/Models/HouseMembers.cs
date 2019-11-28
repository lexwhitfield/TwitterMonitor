using System;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class HouseMembers
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int HouseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EndReason { get; set; }
        public string EndNotes { get; set; }

        public Member Member { get; set; }
        public House House { get; set; }
    }
}
