using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Constituency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ConstituencyTypeId { get; set; }
        public string PrevConstituencyId { get; set; }
        public int? OldDodsId { get; set; }
        public int? OldDisId { get; set; }
        public int? ClerksConstituencyId { get; set; }
        public int? GisId { get; set; }
        public int? PcaCode { get; set; }
        public string PconName { get; set; }
        public string OsName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OnsCode { get; set; }
        public string SchoolsSubsidyBand { get; set; }

        public ConstituencyType ConstituencyType { get; set; }
        public ICollection<ConstituencyArea> ConstituencyAreas { get; set; }
    }
}
