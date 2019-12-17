using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            _context.Departments.AddRange(departments);
            await _context.SaveChangesAsync();
        }

        public async void AddElections(List<Election> elections)
        {
            _context.Elections.AddRange(elections);
            await _context.SaveChangesAsync();
        }

        public async void AddElectionTypes(List<ElectionType> electionTypes)
        {
            _context.ElectionTypes.AddRange(electionTypes);
            await _context.SaveChangesAsync();
        }

        public async void AddGenders(List<Gender> genders)
        {
            _context.Genders.AddRange(genders);
            await _context.SaveChangesAsync();
        }

        public async void AddGovernmentPostDepartments(List<GovernmentPostDepartment> governmentPostDepartments)
        {
            _context.GovernmentPostDepartments.AddRange(governmentPostDepartments);
            await _context.SaveChangesAsync();
        }

        public async void AddGovernmentPostMembers(List<GovernmentPostMember> governmentPostMembers)
        {
            _context.GovernmentPostMembers.AddRange(governmentPostMembers);
            await _context.SaveChangesAsync();
        }

        public async void AddGovernmentPosts(List<GovernmentPost> governmentPosts)
        {
            _context.GovernmentPosts.AddRange(governmentPosts);
            await _context.SaveChangesAsync();
        }

        public async void AddGovernmentRanks(List<GovernmentRank> governmentRanks)
        {
            _context.GovernmentRanks.AddRange(governmentRanks);
            await _context.SaveChangesAsync();
        }

        public async void AddHouseMembers(List<HouseMember> houseMembers)
        {
            _context.HouseMembers.AddRange(houseMembers);
            await _context.SaveChangesAsync();
        }

        public async void AddHouses(List<House> houses)
        {
            _context.Houses.AddRange(houses);
            await _context.SaveChangesAsync();
        }

        public async void AddMembers(List<Member> members)
        {
            _context.Members.AddRange(members);
            await _context.SaveChangesAsync();
        }

        public async void AddOppositionPostDepartments(List<OppositionPostDepartment> oppositionPostDepartments)
        {
            _context.OppositionPostDepartments.AddRange(oppositionPostDepartments);
            await _context.SaveChangesAsync();
        }

        public async void AddOppositionPostMembers(List<OppositionPostMember> oppositionPostMembers)
        {
            _context.OppositionPostMembers.AddRange(oppositionPostMembers);
            await _context.SaveChangesAsync();
        }

        public async void AddOppositionPosts(List<OppositionPost> oppositionPosts)
        {
            _context.OppositionPosts.AddRange(oppositionPosts);
            await _context.SaveChangesAsync();
        }

        public async void AddOppositionRanks(List<OppositionRank> oppositionRanks)
        {
            _context.OppositionRanks.AddRange(oppositionRanks);
            await _context.SaveChangesAsync();
        }

        public async void AddParliamentaryPostMembers(List<ParliamentaryPostMember> parliamentaryPostMembers)
        {
            _context.ParliamentaryPostMembers.AddRange(parliamentaryPostMembers);
            await _context.SaveChangesAsync();
        }

        public async void AddParliamentaryPosts(List<ParliamentaryPost> parliamentaryPosts)
        {
            _context.ParliamentaryPosts.AddRange(parliamentaryPosts);
            await _context.SaveChangesAsync();
        }

        public async void AddParliamentaryRanks(List<ParliamentaryRank> parliamentaryRanks)
        {
            _context.ParliamentaryRanks.AddRange(parliamentaryRanks);
            await _context.SaveChangesAsync();
        }

        public async void AddParties(List<Party> parties)
        {
            _context.Parties.AddRange(parties);
            await _context.SaveChangesAsync();
        }

        public async void AddPartyMembers(List<PartyMember> partyMembers)
        {
            _context.PartyMembers.AddRange(partyMembers);
            await _context.SaveChangesAsync();
        }

        public async void AddTitles(List<Title> titles)
        {
            _context.Titles.AddRange(titles);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Title>> GetTitles()
        {
            return await _context.Titles.ToListAsync();
        }

        public async Task<List<int>> GetMemberIds()
        {
            return await _context.Members.Select(m => m.Id).ToListAsync();
        }

        public async Task<List<int>> GetElectionIds()
        {
            return await _context.Elections.Select(e => e.Id).ToListAsync();
        }

        public async Task<List<int>> GetPartyIds()
        {
            return await _context.Parties.Select(p => p.Id).ToListAsync();
        }

        public async Task<List<int>> GetCommitteeIds()
        {
            return await _context.Committees.Select(c => c.Id).ToListAsync();
        }

        public async Task<Member> GetMember(int memberId)
        {
            return await _context.Members.FindAsync(memberId);
        }

        public async Task<HouseMember> GetHouseMember(int memberId, int houseId)
        {
            return await _context.HouseMembers.FirstOrDefaultAsync(hm => hm.MemberId == memberId && hm.HouseId == houseId);
        }

        public async Task<ConstituencyMember> GetConstituencyMember(int memberId, int constituencyId, int electionId)
        {
            return await _context.ConstituencyMembers.FirstOrDefaultAsync(cm => cm.MemberId == memberId && cm.ConstituencyId == constituencyId && cm.ElectionId == electionId);
        }

        public async Task<CommitteeMember> GetCommitteeMember(int memberId, int committeeId)
        {
            return await _context.CommitteeMembers.FirstOrDefaultAsync(cm => cm.MemberId == memberId && cm.CommitteeId == committeeId);
        }

        public async Task<GovernmentPostMember> GetGovernmentPostMember(int memberId, int governmentPostId)
        {
            return await _context.GovernmentPostMembers.FirstOrDefaultAsync(gpm => gpm.MemberId == memberId && gpm.GovernmentPostId == governmentPostId);
        }

        public async Task<OppositionPostMember> GetOppositionPostMember(int memberId, int oppositionPostId)
        {
            return await _context.OppositionPostMembers.FirstOrDefaultAsync(opm => opm.MemberId == memberId && opm.OppositionPostId == oppositionPostId);
        }

        public async Task<ParliamentaryPostMember> GetParliamentaryPostMember(int memberId, int parliamentaryPostId)
        {
            return await _context.ParliamentaryPostMembers.FirstOrDefaultAsync(ppm => ppm.MemberId == memberId && ppm.ParliamentaryPostId == parliamentaryPostId);
        }

        public async Task<PartyMember> GetPartyMember(int memberId, int partyId)
        {
            return await _context.PartyMembers.FirstOrDefaultAsync(pm => pm.MemberId == memberId && pm.PartyId == partyId);
        }

        public void SaveUpdates()
        {
            _context.SaveChanges();
        }

        public async void AddTwitterUser(int memberId, TwitterUser twitterUser)
        {
            var member = await _context.Members.FindAsync(memberId);
            member.TwitterUserId = twitterUser.Id;

            _context.TwitterUsers.Add(twitterUser);

            _context.SaveChanges();
        }
    }
}
