using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterMonitor.DataModels;

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
