using System;

namespace TwitterMonitor.ViewModels
{
    [Serializable]
    public class MemberViewModel
    {
        public int? Id { get; set; }
        public int? TitleId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public int ConstituencyId { get; set; }
        public string ConstituencyName { get; set; }
        public long? TwitterId { get; set; }
        public string TwitterScreenName { get; set; }
        public DateTime? TwitterCreatedAt { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public bool WhipSuspended { get; set; }
    }
}
