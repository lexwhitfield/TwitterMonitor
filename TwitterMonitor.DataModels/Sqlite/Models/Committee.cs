using System;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Committee
    {
        public int Id { get; set; }
        public int CommitteeTypeId { get; set; }
        public string Name { get; set; }
        public int? ParentCommitteeId { get; set; }
        public DateTime? DateLordsAppointed { get; set; }
        public DateTime? DateCommonsAppointed { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CreatedFromCommitteeId { get; set; }
        public bool IsCommons { get; set; }
        public bool IsLords { get; set; }


        public CommitteeType CommitteeType { get; set; }
    }
}
