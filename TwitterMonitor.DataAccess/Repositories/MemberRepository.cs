using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels.Sqlite;
using TwitterMonitor.DataModels.Sqlite.Models;
using Z.EntityFramework.Plus;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberSqliteDBContext _context;

        public MemberRepository()
        {
            _context = new MemberSqliteDBContext();
        }

        public async Task<Member> GetById(int id)
        {
            var member = await _context.Members
                .Include(m => m.Constituencies)
                .FirstOrDefaultAsync(m => m.Id == id);

            return member;
        }

        public async Task<IEnumerable<Member>> GetAll(string name, int? partyId, string constituencyName, int? electionId, int? constituencyId)
        {
            IQueryable<Member> dbQuery = _context.Members.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                dbQuery = dbQuery.Where(m => m.Forename.Contains(name) || m.Surname.Contains(name));
            //|| (m.Forename + m.Surname).Contains(name, StringComparison.InvariantCultureIgnoreCase));

            if (partyId.HasValue)
                dbQuery = dbQuery.Where(m => m.Parties.Any(p => p.PartyId == partyId.Value));

            if (!string.IsNullOrEmpty(constituencyName))
                dbQuery = dbQuery.Where(m => m.Constituencies.Any(c => c.Constituency.Name.Contains(constituencyName)));

            if (electionId.HasValue)
                dbQuery = dbQuery.Where(m => m.Constituencies.Any(c => c.ElectionId == electionId));

            if (constituencyId.HasValue)
                dbQuery = dbQuery.Where(m => m.Constituencies.Any(c => c.ConstituencyId == constituencyId));

            dbQuery = dbQuery.IncludeFilter(m => m.Title);
            dbQuery = dbQuery.IncludeFilter(m => m.Gender);
            dbQuery = dbQuery.IncludeFilter(m => m.TwitterUser);
            dbQuery = dbQuery.IncludeFilter(m => m.GovernmentPosts.Select(gpm => gpm));
            dbQuery = dbQuery.IncludeFilter(m => m.OppositionPosts.Select(opm => opm));
            dbQuery = dbQuery.IncludeFilter(m => m.ParliamentaryPosts.Select(ppm => ppm));

            if (electionId.HasValue || constituencyId.HasValue)
            {
                if (electionId.HasValue && constituencyId.HasValue)
                    dbQuery = dbQuery
                        .IncludeFilter(m => m.Constituencies.Where(cm => cm.ElectionId == electionId && cm.ConstituencyId == constituencyId))
                        .IncludeFilter(m => m.Constituencies.Where(cm => cm.ElectionId == electionId && cm.ConstituencyId == constituencyId).Select(c => c.Constituency))
                        .IncludeFilter(m => m.Constituencies.Where(cm => cm.ElectionId == electionId && cm.ConstituencyId == constituencyId).Select(cm => cm.Election));
                else if (electionId.HasValue)
                    dbQuery = dbQuery
                        .IncludeFilter(m => m.Constituencies.Where(cm => cm.ElectionId == electionId))
                        .IncludeFilter(m => m.Constituencies.Where(cm => cm.ElectionId == electionId).Select(c => c.Constituency))
                        .IncludeFilter(m => m.Constituencies.Where(cm => cm.ElectionId == electionId).Select(cm => cm.Election));
                else
                    dbQuery = dbQuery
                        .IncludeFilter(m => m.Constituencies.Where(cm => cm.ConstituencyId == constituencyId))
                        .IncludeFilter(m => m.Constituencies.Where(cm => cm.ConstituencyId == constituencyId).Select(c => c.Constituency))
                        .IncludeFilter(m => m.Constituencies.Where(cm => cm.ConstituencyId == constituencyId).Select(cm => cm.Election));
            }
            else
                dbQuery = dbQuery
                    .IncludeFilter(m => m.Constituencies.Select(c => c))
                    .IncludeFilter(m => m.Constituencies.Select(cm => cm.Constituency))
                    .IncludeFilter(m => m.Constituencies.Select(cm => cm.Election));

            dbQuery = dbQuery.IncludeFilter(m => m.Committees.Select(cm => cm)).IncludeFilter(m => m.Committees.Select(cm => cm.Committee));
            dbQuery = dbQuery.IncludeFilter(m => m.Parties.Select(pm => pm)).IncludeFilter(m => m.Parties.Select(pm => pm.Party));
            dbQuery = dbQuery.IncludeFilter(m => m.Houses.Select(hm => hm)).IncludeFilter(m => m.Houses.Select(hm => hm.House));

            return await dbQuery.OrderBy(m => m.Surname).ThenBy(m => m.Forename).ToListAsync();
        }

        public async Task<IEnumerable<Member>> GetAllWithTwitter(string name, int? partyId, string constituencyName)
        {
            IQueryable<Member> dbQuery = _context.Members.AsQueryable();
            dbQuery = dbQuery.Where(m => m.TwitterUserId.HasValue);

            if (!string.IsNullOrEmpty(name))
                dbQuery = dbQuery.Where(m => m.Forename.Contains(name) || m.Surname.Contains(name));
            //|| (m.Forename + m.Surname).Contains(name, StringComparison.InvariantCultureIgnoreCase));

            if (partyId.HasValue)
                dbQuery = dbQuery.Where(m => m.Parties.Any(p => p.PartyId == partyId.Value));

            if (!string.IsNullOrEmpty(constituencyName))
                dbQuery = dbQuery.Where(m => m.Constituencies.Any(c => c.Constituency.Name.Contains(constituencyName)));

            dbQuery = dbQuery.Include(m => m.Title);
            dbQuery = dbQuery.Include(m => m.Gender);
            dbQuery = dbQuery.Include(m => m.TwitterUser);
            dbQuery = dbQuery.Include(m => m.Constituencies).ThenInclude(cm => cm.Constituency);
            dbQuery = dbQuery.Include(m => m.Committees).ThenInclude(cm => cm.Committee);
            dbQuery = dbQuery.Include(m => m.GovernmentPosts);
            dbQuery = dbQuery.Include(m => m.OppositionPosts);
            dbQuery = dbQuery.Include(m => m.ParliamentaryPosts);
            dbQuery = dbQuery.Include(m => m.Parties).ThenInclude(pm => pm.Party);
            dbQuery = dbQuery.Include(m => m.Houses).ThenInclude(hm => hm.House);

            return await dbQuery.OrderBy(m => m.Surname).ThenBy(m => m.Forename).ToListAsync();
        }

        public async Task<Member> Add(Member member)
        {
            _context.Set<Member>().Add(member);
            await _context.SaveChangesAsync();

            return member;
        }

        public async Task<Member> Update(int id, Member member)
        {
            _context.Entry(member).State = EntityState.Modified;
            _context.Set<Member>().Update(member);
            await _context.SaveChangesAsync();

            return member;
        }

        public async Task<bool> Delete(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                // throw an error
                return false;
            }

            // clean up any tables with member as a foreign key

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
