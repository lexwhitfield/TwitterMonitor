using System;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class OppositionPost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OppositionRankId { get; set; }
        public bool Promoted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string HansardName { get; set; }


        public OppositionRank OppositionRank { get; set; }
    }
}
