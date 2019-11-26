using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Interfaces
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Area>> GetAll();
        Task<Area> GetById(int id);
        Task<IEnumerable<AreaType>> GetAreaTypes();
    }
}
