using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels.Sqlite;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly MemberSqliteDBContext _context;

        public AreaRepository()
        {
            _context = new MemberSqliteDBContext();
        }

        public async Task<IEnumerable<Area>> GetAll()
        {
            var areas = await _context.Area
                .Include(a => a.AreaType)
                .ToListAsync();

            return areas;
        }

        public async Task<Area> GetById(int id)
        {
            var area = await _context.Area
                .Include(a => a.AreaType)
                .FirstOrDefaultAsync(a => a.Id == id);

            return area;
        }

        public async void AddMany(List<Area> areas)
        {
            await _context.AddRangeAsync(areas);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AreaType>> GetAreaTypes()
        {
            var areaTypes = await _context.AreaType.ToListAsync();
            return areaTypes;
        }
    }
}
