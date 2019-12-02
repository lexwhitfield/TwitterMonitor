using System;

namespace TwitterMonitor.ViewModels.ViewModels
{
    public class ConstituencyViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? ConstituencyTypeId { get; set; }
        public string ConstituencyTypeName { get; set; }
        public int? PreviousConstituencyId { get; set; }
        public string PreviousConstituencyName { get; set; }
        public int? OldDodsId { get; set; }
        public int? OldDisId { get; set; }
        public int? ClerksConstituencyId { get; set; }
        public int? GisId { get; set; }
        public int? PcaCode { get; set; }
        public string PconName { get; set; }
        public string OsName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OnsCode { get; set; }
        public string SchoolSubsidyBand { get; set; }
        public string Areas { get; set; }
        public int? CurrentMemberId { get; set; }
        public string CurrentMemberName { get; set; }
        public int? CurrentPartyId { get; set; }
        public string CurrentPartyName { get; set; }
        public string CurrentPartyColour { get; set; }
    }
}
