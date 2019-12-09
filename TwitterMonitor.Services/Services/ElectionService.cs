using System.Collections.Generic;
using System.Linq;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Transform;
using TwitterMonitor.ViewModels.ViewModels;

namespace TwitterMonitor.Services.Services
{
    public class ElectionService : IElectionService
    {
        private readonly IElectionRepository _electionRepository;

        public ElectionService()
        {
            _electionRepository = new ElectionRepository();
        }

        public IEnumerable<ElectionViewModel> GetAll(int? electionTypeId)
        {
            var elections = _electionRepository.GetAll(electionTypeId).Result;
            return elections.Select(ModelTransformer.ElectionToElectionViewModel);
        }

        public IEnumerable<KeyValueViewModel> GetElectionTypes()
        {
            var electionTypes = _electionRepository.GetElectionTypes().Result;
            return electionTypes.Select(ModelTransformer.ElectionTypeToKeyValueViewModel);
        }
    }
}
