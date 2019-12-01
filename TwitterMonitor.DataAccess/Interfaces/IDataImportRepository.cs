using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Interfaces
{
    public interface IDataImportRepository
    {
        // References
        void AddGenders(List<Gender> genders);
        void AddHouses(List<House> houses);
        void AddAreaTypes(List<AreaType> areaTypes);
        void AddConstituencyTypes(List<ConstituencyType> constituencyTypes);
        void AddTitles(List<Title> titles);
        void AddElectionTypes(List<ElectionType> electionTypes);
        void AddCommitteeTypes(List<CommitteeType> committeeTypes);
        void AddDepartments(List<Department> departments);
        void AddGovernmentRanks(List<GovernmentRank> governmentRanks);
        void AddGovernmentPosts(List<GovernmentPost> governmentPosts);
        void AddOppositionRanks(List<OppositionRank> oppositionRanks);
        void AddOppositionPosts(List<OppositionPost> oppositionPosts);
        void AddParliamentaryRanks(List<ParliamentaryRank> parliamentaryRanks);
        void AddParliamentaryPosts(List<ParliamentaryPost> parliamentaryPosts);

        // Data
        void AddAreas(List<Area> areas);
        void AddConstituencies(List<Constituency> constituencies);
        void AddElections(List<Election> elections);
        void AddParties(List<Party> parties);
        void AddCommittees(List<Committee> committees);
        void AddMembers(List<Member> members);

        // Joins
        void AddConstituencyAreas(List<ConstituencyArea> constituencyAreas);
        void AddConstituencyMembers(List<ConstituencyMember> constituencyMembers);
        void AddHouseMembers(List<HouseMember> houseMembers);
        void AddCommitteeMembers(List<CommitteeMember> committeeMembers);
        void AddGovernmentPostMembers(List<GovernmentPostMember> governmentPostMembers);
        void AddGovernmentPostDepartments(List<GovernmentPostDepartment> governmentPostDepartments);
        void AddOppositionPostMembers(List<OppositionPostMember> oppositionPostMembers);
        void AddOppositionPostDepartments(List<OppositionPostDepartment> oppositionPostDepartments);
        void AddParliamentaryPostMembers(List<ParliamentaryPostMember> parliamentaryPostMembers);
        void AddPartyMembers(List<PartyMember> partyMembers);


        Task<List<Title>> GetTitles();
    }
}
