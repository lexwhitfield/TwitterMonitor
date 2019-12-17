using System;

namespace TwitterMonitor.ViewModels.ViewModels
{
    public class MemberViewModel
    {
        public int? Id { get; set; }
        public int? DodsId { get; set; }
        public int? PimsId { get; set; }
        public int? ClerksId { get; set; }

        public int? TitleId { get; set; }
        public string TitleName { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        public string TwitterUserName { get; set; }
        public long? TwitterId { get; set; }

        public int? GenderId { get; set; }
        public string GenderName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }

        public int? LatestHouseId { get; set; }
        public string LatestHouseName { get; set; }

        public int? LatestConstituencyId { get; set; }
        public string LatestConstituencyName { get; set; }

        public int? LatestElectionId { get; set; }
        public string LatestElectionName { get; set; }

        public int? LatestPartyId { get; set; }
        public string LatestPartyName { get; set; }
        public string LatestPartyBgColour { get; set; }
        public string LatestPartyTextColour { get; set; }

        public int NumberOfGovernmentPosts { get; set; }
        public int NumberOfOppositionPosts { get; set; }
        public int NumberOfParliamentaryPosts { get; set; }
        public int NumberOfCommittees { get; set; }
    }
}
