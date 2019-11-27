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
using System;
using TwitterMonitor.DataModels.Sqlite.Models;

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

            List<Area> areasToAdd = new List<Area>();

            foreach (XmlNode areaElement in areaElements)
            {
                var idNode = areaElement.SelectSingleNode("Area_Id");
                var nameNode = areaElement.SelectSingleNode("Name");
                var onsIdNode = areaElement.SelectSingleNode("OnsAreaId");
                var areaTypeIdNode = areaElement.SelectSingleNode("AreaType_Id");

                int id = Convert.ToInt32(idNode.InnerText);
                string name = nameNode.InnerText;
                string onsId = onsIdNode.InnerText;
                int areaTypeId = Convert.ToInt32(areaTypeIdNode.InnerText);

                areasToAdd.Add(new Area
                {
                    Id = id,
                    Name = name,
                    OnsId = onsId,
                    AreaTypeId = areaTypeId
                });
            }

            _areaRepository.AddMany(areasToAdd);

            return true;
        }

        public async Task<IEnumerable<KeyValueViewModel>> GetAreaTypes()
        {
            var areaTypes = await _areaRepository.GetAreaTypes();
            return areaTypes.Select(ModelTransformer.AreaTypeToKeyValueViewModel);
        }
    }
}
