using System;

namespace TwitterMonitor.ViewModels.ViewModels
{
    public class CommitteeViewModel
    {
        public int? Id { get; set; }
        public int? CommitteeTypeId { get; set; }
        public string CommitteeTypeName { get; set; }
        public string Name { get; set; }
        public int? ParentCommitteeId { get; set; }
        public string ParentCommitteeName { get; set; }
        public DateTime? DateLordsAppointed { get; set; }
        public DateTime? DateCommonsAppointed { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CreatedFromCommitteeId { get; set; }
        public string CreatedFromCommitteeName { get; set; }
        public bool? IsCommons { get; set; }
        public bool? IsLords { get; set; }
    }
}
