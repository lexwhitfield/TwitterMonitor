using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.ViewModels.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface IPartyService
    {
        Task<IEnumerable<PartyViewModel>> GetAll(string name, bool withMembers = false, bool withActiveMembers = false);
    }
}
