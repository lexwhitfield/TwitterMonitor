using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels.Sqlite;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class ConstituencyRepository : IConstituencyRepository
    {
        private readonly MemberSqliteDBContext _context;

        public ConstituencyRepository()
        {
            _context = new MemberSqliteDBContext();
        }

        public async Task<IEnumerable<Constituency>> GetAll(string name, int? constituencyTypeId, int? areaId, int? partyId, bool? current)
        {
            IQueryable<Constituency> dbQuery = _context.Constituencies
                .Include(c => c.ConstituencyType)
                .Include(c => c.ConstituencyAreas)
                .ThenInclude(ca => ca.Area)
                .Include(c => c.ConstituencyMembers)
                .ThenInclude(cm => cm.Member)
                .ThenInclude(m => m.Parties)
                .ThenInclude(p => p.Party)
                .AsQueryable();

            if (current.HasValue)
                dbQuery = dbQuery.Where(c => !c.EndDate.HasValue);

            if (!string.IsNullOrEmpty(name))
                dbQuery = dbQuery.Where(c => c.Name.Contains(name));

            if (constituencyTypeId.HasValue)
                dbQuery = dbQuery.Where(c => c.ConstituencyTypeId == constituencyTypeId);

            if (areaId.HasValue)
                dbQuery = dbQuery.Where(c => c.ConstituencyAreas.Any(ca => ca.AreaId == areaId));

            if (partyId.HasValue)
                dbQuery = dbQuery.Where(c => c.ConstituencyMembers.Any(cm => cm.Member.Parties.Any(p => p.PartyId == partyId)));

            return await dbQuery.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Constituency> GetById(int id)
        {
            var constituency = await _context.Constituencies
                .FirstOrDefaultAsync(c => c.Id == id);

            return constituency;
        }

        public async Task<Constituency> Add(Constituency constituency)
        {
            _context.Set<Constituency>().Add(constituency);
            await _context.SaveChangesAsync();

            return constituency;
        }

        public async Task<Constituency> Update(Constituency constituency)
        {
            _context.Entry(constituency).State = EntityState.Modified;
            _context.Set<Constituency>().Update(constituency);
            await _context.SaveChangesAsync();

            return constituency;
        }

        public async Task<bool> Delete(int id)
        {
            var constituency = await _context.Constituencies.FindAsync(id);
            if (constituency == null)
            {
                return false;
            }

            _context.Constituencies.Remove(constituency);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ConstituencyType>> GetConstituencTypes()
        {
            return await _context.ConstituencyTypes.ToListAsync();

        }
    }
}
