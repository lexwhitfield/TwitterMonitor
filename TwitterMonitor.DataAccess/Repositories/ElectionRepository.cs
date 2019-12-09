using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels.Sqlite;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class ElectionRepository : IElectionRepository
    {
        private readonly MemberSqliteDBContext _context;

        public ElectionRepository()
        {
            _context = new MemberSqliteDBContext();
        }

        public async Task<IEnumerable<Election>> GetAll(int? electionTypeId)
        {
            IQueryable<Election> dbQuery = _context.Elections.Include(e => e.ElectionType);

            if (electionTypeId.HasValue)
                dbQuery = dbQuery.Where(e => e.ElectionTypeId == electionTypeId);

            dbQuery = dbQuery.Include(e => e.Members);

            return await dbQuery.OrderBy(e => e.ElectionDate).ToListAsync();
        }

        public async Task<IEnumerable<ElectionType>> GetElectionTypes()
        {
            return await _context.ElectionTypes.ToListAsync();
        }
    }
}
