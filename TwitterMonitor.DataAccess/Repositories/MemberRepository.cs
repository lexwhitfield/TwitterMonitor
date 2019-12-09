using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels.Sqlite;
using TwitterMonitor.DataModels.Sqlite.Models;

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

        public async Task<IEnumerable<Member>> GetAll(string name, int? partyId, string constituencyName)
        {
            IQueryable<Member> dbQuery = _context.Members.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                dbQuery = dbQuery.Where(m => m.Forename.Contains(name) || m.Surname.Contains(name));
            //|| (m.Forename + m.Surname).Contains(name, StringComparison.InvariantCultureIgnoreCase));

            if (partyId.HasValue)
                dbQuery = dbQuery.Where(m => m.Parties.Any(p => p.PartyId == partyId.Value));

            if (!string.IsNullOrEmpty(constituencyName))
                dbQuery = dbQuery.Where(m => m.Constituencies.Any(c => c.Constituency.Name.Contains(constituencyName)));

            dbQuery = dbQuery.Include(m => m.Title);
            dbQuery = dbQuery.Include(m => m.Gender);
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
