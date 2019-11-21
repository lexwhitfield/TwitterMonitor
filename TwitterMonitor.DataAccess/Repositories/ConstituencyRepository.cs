using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels.SqlServer;
using TwitterMonitor.DataModels.SqlServer.Models;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class ConstituencyRepository : IConstituencyRepository
    {
        private readonly MemberSqlServerDBContext _context;

        public ConstituencyRepository()
        {
            _context = new MemberSqlServerDBContext();
        }

        public async Task<IEnumerable<Constituency>> GetAll()
        {
            var constituencies = await _context.Constituency
                .Include(c => c.Authority)
                .Include(c => c.Authority.Region)
                .Include(c => c.Authority.Region.Country)
                .OrderBy(c => c.Name)
                .ToListAsync();

            return constituencies;
        }

        public async Task<Constituency> GetById(int id)
        {
            var constituency = await _context.Constituency
                .Include(c => c.Authority)
                .Include(c => c.Authority.Region)
                .Include(c => c.Authority.Region.Country)
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
            var constituency = await _context.Constituency.FindAsync(id);
            if (constituency == null)
            {
                return false;
            }

            _context.Constituency.Remove(constituency);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
