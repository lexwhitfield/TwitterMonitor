using System.Collections.Generic;
using System.Linq;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Transform;
using TwitterMonitor.ViewModels.ViewModels;

namespace TwitterMonitor.Services.Services
{
    public class ConstituencyService : IConstituencyService
    {
        private readonly IConstituencyRepository _constituencyRepository;
        private readonly IAreaRepository _areaRepository;

        public ConstituencyService()
        {
            _constituencyRepository = new ConstituencyRepository();
            _areaRepository = new AreaRepository();
        }

        public IEnumerable<ConstituencyViewModel> GetAll(string name, int? constituencyTypeId, int? areaId, int? partyId, bool? current)
        {
            var constituencies = _constituencyRepository.GetAll(name, constituencyTypeId, areaId, partyId, current).Result;
            return constituencies.Select(ModelTransformer.ConstituencyToConstituencyViewModel);
        }

        public IEnumerable<KeyValueViewModel> GetAreas()
        {
            var areas = _areaRepository.GetAll().Result;
            return areas.Select(ModelTransformer.AreaToKeyValueViewModel);
        }

        public IEnumerable<KeyValueViewModel> GetConstituencyTypes()
        {
            var types = _constituencyRepository.GetConstituencTypes().Result;
            return types.Select(ModelTransformer.ConstituencyTypeToKeyValueViewModel);
        }
    }
}
