using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.ViewModels;
using TwitterMonitor.Transform;
using System.Net.Http;
using System.Xml;

namespace TwitterMonitor.Services.Services
{
    public class AreaService: IAreaService
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

        public async Task<bool> ImportAreas()
        {
            // http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Areas/

            HttpClient client = new HttpClient();
            var areaData = await client.GetStringAsync("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Areas/");

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(areaData);

            var areaElements = xml.GetElementsByTagName("Area");

            foreach (var areaElement in areaElements)
            {

            }

            return true;
        }

        public async Task<IEnumerable<KeyValueViewModel>> GetAreaTypes()
        {
            var areaTypes = await _areaRepository.GetAreaTypes();
            return areaTypes.Select(ModelTransformer.AreaTypeToKeyValueViewModel);
        }
    }
}
