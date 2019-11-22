using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.DataModels.SqlServer.Models;

namespace TwitterMonitor.DataAccess.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Events>> GetAll();
        Task<Events> GetById(int id);
        Task<Events> Add(Events eventViewModel);
        Task<Events> Update(Events eventViewModel);
        Task<bool> Delete(int id);
    }
}
