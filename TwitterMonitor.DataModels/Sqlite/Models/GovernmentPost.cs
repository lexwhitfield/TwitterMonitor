using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class GovernmentPost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GovernmentRankId { get; set; }
        public bool Promoted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string HansardName { get; set; }


        public GovernmentRank GovernmentRank { get; set; }
        public ICollection<GovernmentPostDepartment> Departments { get; set; }
        public ICollection<GovernmentPostMember> Members { get; set; }
    }
}
