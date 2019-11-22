using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Interfaces
{
    public interface IConstituencyRepository
    {
        Task<IEnumerable<Constituency>> GetAll();
        Task<Constituency> GetById(int id);
        Task<Constituency> Add(Constituency constituency);
        Task<Constituency> Update(Constituency constituency);
        Task<bool> Delete(int id);
    }
}
