using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Interfaces
{
    public interface IElectionRepository
    {
        Task<IEnumerable<Election>> GetAll(int? electionTypeId);
        Task<IEnumerable<ElectionType>> GetElectionTypes();
    }
}
