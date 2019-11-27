using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface IConstituencyService
    {
        Task<IEnumerable<ConstituencyViewModel>> GetAll(string name, int? authorityId, int? regionId, int? countryId);
        Task<ConstituencyViewModel> GetById(int id);
        Task<ConstituencyViewModel> Add(ConstituencyViewModel constituencyViewModel);
        void ImportConstituencies();
        void ImportConstituencyAreas();
        Task<ConstituencyViewModel> Update(ConstituencyViewModel constituencyViewModel);
        Task<bool> Delete(int id);
    }
}
