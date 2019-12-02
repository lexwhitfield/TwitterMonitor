using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class OppositionPost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? OppositionRankId { get; set; }
        public bool Promoted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string HansardName { get; set; }


        public OppositionRank OppositionRank { get; set; }
        public ICollection<OppositionPostDepartment> Departments { get; set; }
        public ICollection<OppositionPostMember> Members { get; set; }
    }
}
