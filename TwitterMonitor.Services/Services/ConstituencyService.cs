using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.DataModels.Sqlite.Models;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Transform;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services.Services
{
    public class ConstituencyService : IConstituencyService
    {
        private readonly IConstituencyRepository _constituencyRepository;

        public ConstituencyService()
        {
            _constituencyRepository = new ConstituencyRepository();
        }

        public async Task<IEnumerable<ConstituencyViewModel>> GetAll(string name, int? authorityId, int? regionId, int? countryId)
        {
            var constituencies = await _constituencyRepository.GetAll(name, authorityId, regionId, countryId);
            return constituencies.Select(ModelTransformer.ConstituencyToConstituencyViewModel);
        }

        public async Task<ConstituencyViewModel> GetById(int id)
        {
            var constituency = await _constituencyRepository.GetById(id);
            return ModelTransformer.ConstituencyToConstituencyViewModel(constituency);
        }
        public async Task<ConstituencyViewModel> Add(ConstituencyViewModel constituencyViewModel)
        {
            var constituency = await _constituencyRepository.Add(ModelTransformer.ConstituencyViewModelToConstituency(constituencyViewModel));
            return ModelTransformer.ConstituencyToConstituencyViewModel(constituency);
        }

        public async void ImportConstituencies()
        {
            // http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Constituencies/

            using HttpClient client = new HttpClient();
            var constituencyData = await client.GetStringAsync("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Constituencies/");

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(constituencyData);

            var constituencyElements = xml.GetElementsByTagName("Constituency");

            List<ConstituencyNew> constituenciesToAdd = new List<ConstituencyNew>();

            foreach (XmlNode constituencyElement in constituencyElements)
            {
                var idNode = constituencyElement.SelectSingleNode("Constituency_Id");
                var nameNode = constituencyElement.SelectSingleNode("Name");
                var constituencyTypeNode = constituencyElement.SelectSingleNode("ConstituencyType_Id");
                var prevConstituencyIdNode = constituencyElement.SelectSingleNode("PrevConstituencyId");
                var oldDodsIdNode = constituencyElement.SelectSingleNode("OldDodsId");
                var oldDisIdNode = constituencyElement.SelectSingleNode("OldDisId");
                var clerksConstituencyIdNode = constituencyElement.SelectSingleNode("ClerksConstituencyId");
                var gisIdNode = constituencyElement.SelectSingleNode("GisId");
                var pcaCodeNode = constituencyElement.SelectSingleNode("PcaCode");
                var pconNameNode = constituencyElement.SelectSingleNode("PconName");
                var osNameNode = constituencyElement.SelectSingleNode("OsName");
                var startDateNode = constituencyElement.SelectSingleNode("StartDate");
                var endDateNode = constituencyElement.SelectSingleNode("EndDate");
                var onsCodeNode = constituencyElement.SelectSingleNode("ONSCode");
                var schoolsSubsidyBandNode = constituencyElement.SelectSingleNode("SchoolsSubsidyBand");

                int id = Convert.ToInt32(idNode.InnerText);
                string name = nameNode.InnerText;
                int? constituencyTypeId = ToNullableInt(constituencyTypeNode.InnerText);
                string prevConstituencyId = prevConstituencyIdNode.InnerText;
                int? oldDodsId = ToNullableInt(oldDodsIdNode.InnerText);
                int? oldDisId = ToNullableInt(oldDisIdNode.InnerText);
                int? clerksConstituencyId = ToNullableInt(clerksConstituencyIdNode.InnerText);
                int? gisId = ToNullableInt(gisIdNode.InnerText);
                int? pcaCode = ToNullableInt(pcaCodeNode.InnerText);
                string pconName = pconNameNode.InnerText;
                string osName = osNameNode.InnerText;
                DateTime startDate = DateTime.Parse(startDateNode.InnerText);
                DateTime? endDate = null;
                if (!string.IsNullOrEmpty(endDateNode.InnerText))
                    endDate = DateTime.Parse(endDateNode.InnerText);
                string onsCode = onsCodeNode.InnerText;
                string schoolsSubsidyBand = schoolsSubsidyBandNode.InnerText;

                constituenciesToAdd.Add(new ConstituencyNew
                {
                    Id = id,
                    Name = name,
                    ConstituencyTypeId = constituencyTypeId,
                    PrevConstituencyId = prevConstituencyId,
                    OldDodsId = oldDodsId,
                    OldDisId = oldDisId,
                    ClerksConstituencyId = clerksConstituencyId,
                    GisId = gisId,
                    PcaCode = pcaCode,
                    PconName = pconName,
                    OsName = osName,
                    StartDate = startDate,
                    EndDate = endDate,
                    OnsCode = onsCode,
                    SchoolsSubsidyBand = schoolsSubsidyBand
                });
            }

            _constituencyRepository.AddMany(constituenciesToAdd);
        }

        public async void ImportConstituencyAreas()
        {
            // http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ConstituencyAreas/

            using HttpClient client = new HttpClient();
            var constituencyAreaData = await client.GetStringAsync("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ConstituencyAreas/");

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(constituencyAreaData);

            var constituencyAreaElements = xml.GetElementsByTagName("ConstituencyArea");

            List<ConstituencyArea> constituencyAreasToAdd = new List<ConstituencyArea>();

            foreach (XmlNode constituencyAreaElement in constituencyAreaElements)
            {

            }
        }

        public static int? ToNullableInt(string s)
        {
            int i;
            if (int.TryParse(s, out i))
            {
                if (i == 0)
                    return null;
                return i;
            }
            return null;
        }

        public async Task<ConstituencyViewModel> Update(ConstituencyViewModel constituencyViewModel)
        {
            var original = await _constituencyRepository.GetById(constituencyViewModel.Id.Value);
            var constituency = await _constituencyRepository.Update(ModelTransformer.ConstituencyViewModelToConstituency(constituencyViewModel, original));
            return ModelTransformer.ConstituencyToConstituencyViewModel(constituency);
        }

        public async Task<bool> Delete(int id)
        {
            var success = await _constituencyRepository.Delete(id);
            return success;
        }
    }
}
