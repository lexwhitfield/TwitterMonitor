using System;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class ParliamentaryPost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParliamentaryRankId { get; set; }
        public bool ExcludeFromCount { get; set; }
        public bool Promoted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCommons { get; set; }
        public bool IsLords { get; set; }
        public string HansardName { get; set; }


        public ParliamentaryRank ParliamentaryRank { get; set; }
    }
}
