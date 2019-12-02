using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.ViewModels;
using TwitterMonitor.ViewModels.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface IPartyService
    {
        Task<IEnumerable<PartyViewModel>> GetAll();
    }
}
