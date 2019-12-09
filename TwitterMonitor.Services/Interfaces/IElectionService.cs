using System.Collections.Generic;
using TwitterMonitor.ViewModels.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface IElectionService
    {
        IEnumerable<ElectionViewModel> GetAll(int? electionTypeId);
        IEnumerable<KeyValueViewModel> GetElectionTypes();
    }
}
