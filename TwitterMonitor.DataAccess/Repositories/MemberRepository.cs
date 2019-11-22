using Microsoft.EntityFrameworkCore;
using System;
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
            var member = await _context.Member
                .Include(m => m.Constituency)
                .Include(m => m.Party)
                .Include(m => m.Twitter)
                .FirstOrDefaultAsync(m => m.Id == id);

            return member;
        }

        public async Task<IEnumerable<Member>> GetAll(int? id, string name, int? partyId, string constituency, string twitterName)
        {
            var members = await _context.Member
                .Include(m => m.Constituency)
                .Include(m => m.Party)
                .Include(m => m.Twitter)
                .ToListAsync();

            if (id.HasValue)
                members = members.Where(m => m.Id == id.Value).ToList();

            if (!string.IsNullOrEmpty(name))
                members = members.Where(m => m.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToList();

            if (partyId.HasValue)
                members = members.Where(m => m.PartyId == partyId.Value).ToList();

            if (!string.IsNullOrEmpty(constituency))
                members = members.Where(m => m.Constituency.Name.Contains(constituency, StringComparison.InvariantCultureIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(twitterName))
                members = members.Where(m => m.TwitterId.HasValue)
                    .Where(m => m.Twitter.ScreenName.Contains(twitterName, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return members.OrderBy(m => m.Name);
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
            var member = await _context.Member.FindAsync(id);

            if (member == null)
            {
                // throw an error
                return false;
            }

            // clean up any tables with member as a foreign key

            _context.Member.Remove(member);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
