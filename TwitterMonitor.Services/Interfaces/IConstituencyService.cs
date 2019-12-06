using System.Collections.Generic;
using TwitterMonitor.ViewModels.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface IConstituencyService
    {
        IEnumerable<KeyValueViewModel> GetAreas();
        IEnumerable<KeyValueViewModel> GetConstituencyTypes();
        IEnumerable<ConstituencyViewModel> GetAll(string name, int? constituencyTypeId, int? areaId, int? partyId, bool? current);
    }
}
