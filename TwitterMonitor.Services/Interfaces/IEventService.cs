using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventViewModel>> GetAll();
        Task<EventViewModel> GetById(int id);
        Task<EventViewModel> Add(EventViewModel eventViewModel);
        Task<EventViewModel> Update(EventViewModel eventViewModel);
        Task<bool> Delete(int id);
    }
}
