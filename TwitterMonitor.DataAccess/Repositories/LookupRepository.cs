using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels.Sqlite;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        private readonly MemberSqliteDBContext _context;

        public LookupRepository()
        {
            _context = new MemberSqliteDBContext();
        }
    }
}
