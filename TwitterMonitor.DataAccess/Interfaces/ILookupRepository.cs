using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Interfaces
{
    public interface ILookupRepository
    {
        Task<IEnumerable<Authority>> GetAuthorities();
        Task<IEnumerable<Region>> GetRegions();
        Task<IEnumerable<Country>> GetCountries();
    }
}
