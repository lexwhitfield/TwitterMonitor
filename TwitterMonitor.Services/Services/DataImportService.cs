using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.Services.Interfaces;

namespace TwitterMonitor.Services.Services
{
    public class DataImportService : IDataImportService
    {
        private readonly IDataImportRepository _dataImportRepository;

        public DataImportService()
        {
            _dataImportRepository = new DataImportRepository();
        }

        public async void ImportReferences()
        {
            // gender
            // houses
            // area types
            // constituency types
            // titles
            // election types
            // committee types
            // departments
            // government ranks
            // government posts
            // opposition ranks
            // opposition posts
            // parliamentary ranks
            // parliamentary posts
        }

        public async void ImportData()
        {
            // areas
            // constituencies
            // elections
            // parties
            // committees
            // members
        }

        public async void ImportJoins()
        {
            // constituency areas
            // constituency members
            // house members
            // committee members
            // government post members
            // government post departments
            // opposition post members
            // opposition post departments
            // parliamentary post members
        }

        public async void ImportAreas()
        {
            //// http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Areas/

            //HttpClient client = new HttpClient();
            //var areaData = await client.GetStringAsync("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Areas/");

            //XmlDocument xml = new XmlDocument();
            //xml.LoadXml(areaData);

            //var areaElements = xml.GetElementsByTagName("Area");

            //List<Area> areasToAdd = new List<Area>();

            //foreach (XmlNode areaElement in areaElements)
            //{
            //    var idNode = areaElement.SelectSingleNode("Area_Id");
            //    var nameNode = areaElement.SelectSingleNode("Name");
            //    var onsIdNode = areaElement.SelectSingleNode("OnsAreaId");
            //    var areaTypeIdNode = areaElement.SelectSingleNode("AreaType_Id");

            //    int id = Convert.ToInt32(idNode.InnerText);
            //    string name = nameNode.InnerText;
            //    string onsId = onsIdNode.InnerText;
            //    int areaTypeId = Convert.ToInt32(areaTypeIdNode.InnerText);

            //    areasToAdd.Add(new Area
            //    {
            //        Id = id,
            //        Name = name,
            //        OnsId = onsId,
            //        AreaTypeId = areaTypeId
            //    });
            //}

            //_dataImportRepository.AddAreas(areasToAdd);
        }

        public async void ImportConstituencies()
        {
            //// http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Constituencies/

            //using HttpClient client = new HttpClient();
            //var constituencyData = await client.GetStringAsync("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Constituencies/");

            //XmlDocument xml = new XmlDocument();
            //xml.LoadXml(constituencyData);

            //var constituencyElements = xml.GetElementsByTagName("Constituency");

            //List<ConstituencyNew> constituenciesToAdd = new List<ConstituencyNew>();

            //foreach (XmlNode constituencyElement in constituencyElements)
            //{
            //    var idNode = constituencyElement.SelectSingleNode("Constituency_Id");
            //    var nameNode = constituencyElement.SelectSingleNode("Name");
            //    var constituencyTypeNode = constituencyElement.SelectSingleNode("ConstituencyType_Id");
            //    var prevConstituencyIdNode = constituencyElement.SelectSingleNode("PrevConstituencyId");
            //    var oldDodsIdNode = constituencyElement.SelectSingleNode("OldDodsId");
            //    var oldDisIdNode = constituencyElement.SelectSingleNode("OldDisId");
            //    var clerksConstituencyIdNode = constituencyElement.SelectSingleNode("ClerksConstituencyId");
            //    var gisIdNode = constituencyElement.SelectSingleNode("GisId");
            //    var pcaCodeNode = constituencyElement.SelectSingleNode("PcaCode");
            //    var pconNameNode = constituencyElement.SelectSingleNode("PconName");
            //    var osNameNode = constituencyElement.SelectSingleNode("OsName");
            //    var startDateNode = constituencyElement.SelectSingleNode("StartDate");
            //    var endDateNode = constituencyElement.SelectSingleNode("EndDate");
            //    var onsCodeNode = constituencyElement.SelectSingleNode("ONSCode");
            //    var schoolsSubsidyBandNode = constituencyElement.SelectSingleNode("SchoolsSubsidyBand");

            //    int id = Convert.ToInt32(idNode.InnerText);
            //    string name = nameNode.InnerText;
            //    int? constituencyTypeId = ToNullableInt(constituencyTypeNode.InnerText);
            //    string prevConstituencyId = prevConstituencyIdNode.InnerText;
            //    int? oldDodsId = ToNullableInt(oldDodsIdNode.InnerText);
            //    int? oldDisId = ToNullableInt(oldDisIdNode.InnerText);
            //    int? clerksConstituencyId = ToNullableInt(clerksConstituencyIdNode.InnerText);
            //    int? gisId = ToNullableInt(gisIdNode.InnerText);
            //    int? pcaCode = ToNullableInt(pcaCodeNode.InnerText);
            //    string pconName = pconNameNode.InnerText;
            //    string osName = osNameNode.InnerText;
            //    DateTime startDate = DateTime.Parse(startDateNode.InnerText);
            //    DateTime? endDate = null;
            //    if (!string.IsNullOrEmpty(endDateNode.InnerText))
            //        endDate = DateTime.Parse(endDateNode.InnerText);
            //    string onsCode = onsCodeNode.InnerText;
            //    string schoolsSubsidyBand = schoolsSubsidyBandNode.InnerText;

            //    constituenciesToAdd.Add(new ConstituencyNew
            //    {
            //        Id = id,
            //        Name = name,
            //        ConstituencyTypeId = constituencyTypeId,
            //        PrevConstituencyId = prevConstituencyId,
            //        OldDodsId = oldDodsId,
            //        OldDisId = oldDisId,
            //        ClerksConstituencyId = clerksConstituencyId,
            //        GisId = gisId,
            //        PcaCode = pcaCode,
            //        PconName = pconName,
            //        OsName = osName,
            //        StartDate = startDate,
            //        EndDate = endDate,
            //        OnsCode = onsCode,
            //        SchoolsSubsidyBand = schoolsSubsidyBand
            //    });
            //}

            //_dataImportRepository.AddConstituencies(constituenciesToAdd);
        }

        public async void ImportConstituencyAreas()
        {
            //// http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ConstituencyAreas/

            //using HttpClient client = new HttpClient();
            //var constituencyAreaData = await client.GetStringAsync("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ConstituencyAreas/");

            //XmlDocument xml = new XmlDocument();
            //xml.LoadXml(constituencyAreaData);

            //var constituencyAreaElements = xml.GetElementsByTagName("ConstituencyArea");

            //List<ConstituencyArea> constituencyAreasToAdd = new List<ConstituencyArea>();

            //foreach (XmlNode constituencyAreaElement in constituencyAreaElements)
            //{
            //    var constituencyIdNode = constituencyAreaElement.SelectSingleNode("Constituency_Id");
            //    var areaIdNode = constituencyAreaElement.SelectSingleNode("Area_Id");
            //    var startDateNode = constituencyAreaElement.SelectSingleNode("StartDate");
            //    var endDateNode = constituencyAreaElement.SelectSingleNode("EndDate");

            //    int constituencyId = Convert.ToInt32(constituencyIdNode.InnerText);
            //    int areaId = Convert.ToInt32(areaIdNode.InnerText);
            //    DateTime startDate = DateTime.Parse(startDateNode.InnerText);
            //    DateTime? endDate = null;
            //    if (!string.IsNullOrEmpty(endDateNode.InnerText))
            //        endDate = DateTime.Parse(endDateNode.InnerText);

            //    constituencyAreasToAdd.Add(new ConstituencyArea
            //    {
            //        ConstituencyId = constituencyId,
            //        AreaId = areaId,
            //        StartDate = startDate,
            //        EndDate = endDate
            //    });
            //}

            //_dataImportRepository.AddConstituencyAreas(constituencyAreasToAdd);
        }

        public async void ImportParties()
        {
            //// http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Parties/

            //using HttpClient client = new HttpClient();
            //var partyData = await client.GetStringAsync("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Parties/");

            //XmlDocument xml = new XmlDocument();
            //xml.LoadXml(partyData);

            //var partyElements = xml.GetElementsByTagName("Party");

            //List<Party> partiesToAdd = new List<Party>();

            //foreach (XmlNode partyElement in partyElements)
            //{
            //    var idNode = partyElement.SelectSingleNode("Party_Id");
            //    var nameNode = partyElement.SelectSingleNode("Name");
            //    var abbrNode = partyElement.SelectSingleNode("Abbreviation");
            //    var initialsNode = partyElement.SelectSingleNode("Initials");
            //    var colourNode = partyElement.SelectSingleNode("Colour");
            //    var textColourNode = partyElement.SelectSingleNode("TextColour");
            //    var isCommonsNode = partyElement.SelectSingleNode("IsCommons");
            //    var isLordsNode = partyElement.SelectSingleNode("IsLords");
            //    var oldDisIdNode = partyElement.SelectSingleNode("OldDISId");
            //    var holMainPartyNode = partyElement.SelectSingleNode("HoLMainParty");
            //    var holOrderNode = partyElement.SelectSingleNode("HoLOrder");
            //    var holIsSpiritualNode = partyElement.SelectSingleNode("HoL_IsSpiritualSide");

            //    int id = Convert.ToInt32(idNode.InnerText);
            //    string name = nameNode.InnerText;
            //    string abbr = abbrNode.InnerText;
            //    string initials = initialsNode.InnerText;
            //    string colour = colourNode.InnerText;
            //    string textColour = textColourNode.InnerText;
            //    bool isCommons = Convert.ToBoolean(isCommonsNode.InnerText);
            //    bool isLords = Convert.ToBoolean(isLordsNode.InnerText);
            //    int? oldDIsId = ToNullableInt(oldDisIdNode.InnerText);
            //    bool holMainParty = Convert.ToBoolean(holMainPartyNode.InnerText);
            //    int? holOrder = ToNullableInt(holOrderNode.InnerText);
            //    bool holIsSpiritualSide = Convert.ToBoolean(holIsSpiritualNode.InnerText);

            //    partiesToAdd.Add(new Party
            //    {
            //        Id = id,
            //        Name = name,
            //        Abbr = abbr,
            //        Initials = initials,
            //        Colour = colour,
            //        TextColour = textColour,
            //        IsCommons = isCommons,
            //        IsLords = isLords,
            //        OldDisId = oldDIsId,
            //        HoLMainParty = holMainParty,
            //        HoLOrder = holOrder,
            //        HoLIsSpiritualSide = holIsSpiritualSide
            //    });
            //}

            //_dataImportRepository.AddParties(partiesToAdd);
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
    }
}
