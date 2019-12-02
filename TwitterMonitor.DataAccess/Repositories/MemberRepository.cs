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

        public async Task<IEnumerable<Member>> GetAll()
        {
            var members = await _context.Members
                .Include(m => m.Title)
                .Include(m => m.Gender)
                .Include(m => m.Constituencies)
                .ThenInclude(cm => cm.Constituency)
                .Include(m => m.Committees)
                .ThenInclude(cm => cm.Committee)
                .Include(m => m.GovernmentPosts)
                .Include(m => m.OppositionPosts)
                .Include(m => m.ParliamentaryPosts)
                .Include(m => m.Parties)
                .ThenInclude(pm => pm.Party)
                .Include(m => m.Houses)
                .ThenInclude(hm => hm.House)
                .ToListAsync();                
            
            return members.OrderBy(m => m.Surname).ThenBy(m => m.Forename);
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
