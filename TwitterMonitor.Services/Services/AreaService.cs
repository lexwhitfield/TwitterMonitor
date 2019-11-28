using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Transform;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;

        public AreaService()
        {
            _areaRepository = new AreaRepository();
        }

        public async Task<IEnumerable<AreaViewModel>> GetAll()
        {
            var areas = await _areaRepository.GetAll();
            return areas.Select(ModelTransformer.AreaToAreaViewModel);
        }

        public async Task<AreaViewModel> GetById(int id)
        {
            var area = await _areaRepository.GetById(id);
            return ModelTransformer.AreaToAreaViewModel(area);
        }

        public async Task<IEnumerable<KeyValueViewModel>> GetAreaTypes()
        {
            var areaTypes = await _areaRepository.GetAreaTypes();
            return areaTypes.Select(ModelTransformer.AreaTypeToKeyValueViewModel);
        }
    }
}
