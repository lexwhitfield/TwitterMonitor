using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Member
    {
        public int Id { get; set; }
        public int? DodsId { get; set; }
        public int? PimsId { get; set; }
        public int? ClerksId { get; set; }
        public int? TitleId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public int GenderId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }


        public Title Title { get; set; }
        public Gender Gender { get; set; }
        public ICollection<HouseMember> Houses { get; set; }
        public ICollection<ConstituencyMember> Constituencies { get; set; }
        public ICollection<GovernmentPostMember> GovernmentPosts { get; set; }
        public ICollection<OppositionPostMember> OppositionPosts { get; set; }
        public ICollection<ParliamentaryPostMember> ParliamentaryPosts { get; set; }
        public ICollection<CommitteeMember> Committees { get; set; }
    }
}
