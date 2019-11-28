using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface IPartyService
    {
        Task<PartyViewModel> GetById(int id);
        Task<IEnumerable<PartyViewModel>> GetAll();
        Task<PartyViewModel> Add(PartyViewModel partyViewModel);
        Task<PartyViewModel> Update(PartyViewModel partyViewModel);
        Task<bool> Delete(int id);
    }
}
