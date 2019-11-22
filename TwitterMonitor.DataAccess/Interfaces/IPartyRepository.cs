using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Interfaces
{
    public interface IPartyRepository
    {
        Task<IEnumerable<Party>> GetAll();
        Task<Party> GetById(int id);
        Task<Party> Add(Party party);
        Task<Party> Update(Party party);
        Task<bool> Delete(int id);
    }
}
