using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface IAreaService
    {
        Task<IEnumerable<AreaViewModel>> GetAll();
        Task<AreaViewModel> GetById(int id);
        Task<IEnumerable<KeyValueViewModel>> GetAreaTypes();
    }
}
