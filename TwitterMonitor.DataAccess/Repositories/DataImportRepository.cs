using System.Collections.Generic;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels.Sqlite;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class DataImportRepository : IDataImportRepository
    {
        private readonly MemberSqliteDBContext _context;

        public DataImportRepository()
        {
            _context = new MemberSqliteDBContext();
        }

        public async void AddAreas(List<Area> areas)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddAreaTypes(List<AreaType> areaTypes)
        {
            _context.AreaTypes.AddRange(areaTypes);
            await _context.SaveChangesAsync();
        }

        public async void AddCommitteeMembers(List<CommitteeMember> committeeMembers)
        {
            _context.CommitteeMembers.AddRange(committeeMembers);
            await _context.SaveChangesAsync();
        }

        public async void AddCommittees(List<Committee> committees)
        {
            _context.Committees.AddRange(committees);
            await _context.SaveChangesAsync();
        }

        public async void AddCommitteeTypes(List<CommitteeType> committeeTypes)
        {
            _context.CommitteeTypes.AddRange(committeeTypes);
            await _context.SaveChangesAsync();
        }

        public async void AddConstituencies(List<Constituency> constituencies)
        {
            _context.Constituencies.AddRange(constituencies);
            await _context.SaveChangesAsync();
        }

        public async void AddConstituencyAreas(List<ConstituencyArea> constituencyAreas)
        {
            _context.ConstituencyAreas.AddRange(constituencyAreas);
            await _context.SaveChangesAsync();
        }

        public async void AddConstituencyMembers(List<ConstituencyMember> constituencyMembers)
        {
            _context.ConstituencyMembers.AddRange(constituencyMembers);
            await _context.SaveChangesAsync();
        }

        public async void AddConstituencyTypes(List<ConstituencyType> constituencyTypes)
        {
            _context.ConstituencyTypes.AddRange(constituencyTypes);
            await _context.SaveChangesAsync();
        }

        public async void AddDepartments(List<Department> departments)
        {
            _context.Departments.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddElections(List<Election> elections)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddElectionTypes(List<ElectionType> electionTypes)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddGenders(List<Gender> genders)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddGovernmentPostDepartments(List<GovernmentPostDepartment> governmentPostDepartments)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddGovernmentPostMembers(List<GovernmentPostMember> governmentPostMembers)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddGovernmentPosts(List<GovernmentPost> governmentPosts)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddGovernmentRanks(List<GovernmentRank> governmentRanks)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddHouseMembers(List<HouseMember> houseMembers)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddHouses(List<House> houses)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddMembers(List<Member> members)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddOppositionPostDepartments(List<OppositionPostDepartment> oppositionPostDepartments)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddOppositionPostMembers(List<OppositionPostMember> oppositionPostMembers)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddOppositionPosts(List<OppositionPost> oppositionPosts)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddOppositionRanks(List<OppositionRank> oppositionRanks)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddParliamentaryPostMembers(List<ParliamentaryPostMember> parliamentaryPostMembers)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddParliamentaryPosts(List<ParliamentaryPost> parliamentaryPosts)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddParliamentaryRanks(List<ParliamentaryRank> parliamentaryRanks)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddParties(List<Party> parties)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }

        public async void AddTitles(List<Title> titles)
        {
            _context.Areas.AddRange(areas);
            await _context.SaveChangesAsync();
        }
    }
}
