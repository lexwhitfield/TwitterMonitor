using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.DataModels.Sqlite.Models;
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

        private async Task<XmlNodeList> GetXmlElements(string uri, string elementName)
        {
            using HttpClient client = new HttpClient();
            var data = await client.GetStringAsync(uri);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(data);

            return xml.GetElementsByTagName(elementName);
        }

        public async void ImportReferences()
        {
            // gender
            List<Gender> genders = new List<Gender>()
            {
                new Gender{ Name = "Male" },
                new Gender{ Name = "Female" },
                new Gender{ Name = "Other" }
            };

            _dataImportRepository.AddGenders(genders);

            // houses
            List<House> houses = new List<House>()
            {
                new House{ Name = "Commons" },
                new House{ Name = "Lords" }
            };

            _dataImportRepository.AddHouses(houses);

            // area types -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/AreaTypes/

            var areaTypeElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/AreaTypes/", "AreaType");
            List<AreaType> areaTypes = new List<AreaType>();

            foreach (XmlNode node in areaTypeElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("AreaType_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;

                areaTypes.Add(new AreaType
                {
                    Id = id,
                    Name = name
                });
            }

            _dataImportRepository.AddAreaTypes(areaTypes);

            // constituency types -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ConstituencyTypes/

            var constituencyTypeElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ConstituencyTypes/", "ConstituencyType");
            List<ConstituencyType> constituencyTypes = new List<ConstituencyType>();

            foreach (XmlNode node in constituencyTypeElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("ConstituencyType_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;

                constituencyTypes.Add(new ConstituencyType
                {
                    Id = id,
                    Name = name
                });
            }

            _dataImportRepository.AddConstituencyTypes(constituencyTypes);

            // titles -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Titles/

            var titleElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Titles/", "Title");
            List<Title> titles = new List<Title>();

            foreach (XmlNode node in titleElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("Title_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;

                titles.Add(new Title
                {
                    Id = id,
                    Name = name
                });
            }

            _dataImportRepository.AddTitles(titles);

            // election types -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ElectionTypes/

            var electionTypeElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ElectionTypes/", "ElectionType");
            List<ElectionType> electionTypes = new List<ElectionType>();

            foreach (XmlNode node in electionTypeElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("ElectionType_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;

                electionTypes.Add(new ElectionType
                {
                    Id = id,
                    Name = name
                });
            }

            _dataImportRepository.AddElectionTypes(electionTypes);

            // committee types -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/CommitteeTypes/

            var committeeTypeElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/CommitteeTypes/", "CommitteeType");
            List<CommitteeType> committeeTypes = new List<CommitteeType>();

            foreach (XmlNode node in committeeTypeElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("CommitteeType_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;

                committeeTypes.Add(new CommitteeType
                {
                    Id = id,
                    Name = name
                });
            }

            _dataImportRepository.AddCommitteeTypes(committeeTypes);

            // departments -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Departments/

            var departmentsElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Departments/", "Department");
            List<Department> departments = new List<Department>();

            foreach (XmlNode node in departmentsElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("Department_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;
                var acronym = node.SelectSingleNode("Acronym").InnerText;
                var minister = Convert.ToBoolean(node.SelectSingleNode("Minister").InnerText);
                var secretary = Convert.ToBoolean(node.SelectSingleNode("Secretary").InnerText);
                var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                DateTime? endDate = null;
                if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                    endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                departments.Add(new Department
                {
                    Id = id,
                    Name = name,
                    Acronym = acronym,
                    Minister = minister,
                    Secretary = secretary,
                    StartDate = startDate,
                    EndDate = endDate
                });
            }

            _dataImportRepository.AddDepartments(departments);

            // government ranks -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/GovernmentRanks/

            var governmentRankElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/GovernmentRanks/", "GovernmentRank");
            List<GovernmentRank> governmentRanks = new List<GovernmentRank>();

            foreach (XmlNode node in governmentRankElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("GovernmentRank_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;
                var ministerialRank = ToNullableInt(node.SelectSingleNode("MinisterialRank").InnerText);
                var statsRank = node.SelectSingleNode("StatsRank").InnerText;
                var clerksRank = node.SelectSingleNode("ClerksRank").InnerText;
                var orderRank = ToNullableInt(node.SelectSingleNode("OrderRank").InnerText);

                governmentRanks.Add(new GovernmentRank
                {
                    Id = id,
                    Name = name,
                    MinisterialRank = ministerialRank,
                    StatsRank = statsRank,
                    ClerksRank = clerksRank,
                    OrderRank = orderRank
                });
            }

            _dataImportRepository.AddGovernmentRanks(governmentRanks);

            // government posts -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/GovernmentPosts/

            var governmentPostElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/GovernmentPosts/", "GovernmentPost");
            List<GovernmentPost> governmentPosts = new List<GovernmentPost>();

            foreach (XmlNode node in governmentPostElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("GovernmentPost_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;
                var governmentRankId = Convert.ToInt32(node.SelectSingleNode("GovernmentRank_Id").InnerText);
                var promoted = Convert.ToBoolean(node.SelectSingleNode("Promoted").InnerText);
                var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                DateTime? endDate = null;
                if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                    endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                var hansardName = node.SelectSingleNode("HansardName").InnerText;

                governmentPosts.Add(new GovernmentPost
                {
                    Id = id,
                    Name = name,
                    GovernmentRankId = governmentRankId,
                    Promoted = promoted,
                    StartDate = startDate,
                    EndDate = endDate,
                    HansardName = hansardName
                });
            }

            _dataImportRepository.AddGovernmentPosts(governmentPosts);

            // opposition ranks -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/OppositionRanks/

            var oppositionRankElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/OppositionRanks/", "OppositionRank");
            List<OppositionRank> oppositionRanks = new List<OppositionRank>();

            foreach (XmlNode node in oppositionRankElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("OppositionRank_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;
                var ministerialRank = ToNullableInt(node.SelectSingleNode("MinisterialRank").InnerText);
                var statsRank = node.SelectSingleNode("StatsRank").InnerText;
                var clerksRank = node.SelectSingleNode("ClerksRank").InnerText;
                var orderRank = ToNullableInt(node.SelectSingleNode("OrderRank").InnerText);

                oppositionRanks.Add(new OppositionRank
                {
                    Id = id,
                    Name = name,
                    MinisterialRank = ministerialRank,
                    StatsRank = statsRank,
                    ClerksRank = clerksRank,
                    OrderRank = orderRank
                });
            }

            _dataImportRepository.AddOppositionRanks(oppositionRanks);

            // opposition posts -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/OppositionPosts/

            var oppositionPostElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/OppositionPosts/", "OppositionPost");
            List<OppositionPost> oppositionPosts = new List<OppositionPost>();

            foreach (XmlNode node in oppositionPostElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("OppositionPost_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;
                var oppositionRankId = Convert.ToInt32(node.SelectSingleNode("OppositionRank_Id").InnerText);
                var promoted = Convert.ToBoolean(node.SelectSingleNode("Promoted").InnerText);
                var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                DateTime? endDate = null;
                if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                    endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                var hansardName = node.SelectSingleNode("HansardName").InnerText;

                oppositionPosts.Add(new OppositionPost
                {
                    Id = id,
                    Name = name,
                    OppositionRankId = oppositionRankId,
                    Promoted = promoted,
                    StartDate = startDate,
                    EndDate = endDate,
                    HansardName = hansardName
                });
            }

            _dataImportRepository.AddOppositionPosts(oppositionPosts);

            // parliamentary ranks -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ParliamentaryRanks/

            var parliamentaryRankElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ParliamentaryRanks/", "ParliamentaryRank");
            List<ParliamentaryRank> parliamentaryRanks = new List<ParliamentaryRank>();

            foreach (XmlNode node in parliamentaryRankElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("ParliamentaryRank_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;

                parliamentaryRanks.Add(new ParliamentaryRank
                {
                    Id = id,
                    Name = name
                });
            }

            _dataImportRepository.AddParliamentaryRanks(parliamentaryRanks);

            // parliamentary posts -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ParliamentaryPosts/

            var parliamentaryPostElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ParliamentaryPosts/", "ParliamentaryPost");
            List<ParliamentaryPost> parliamentaryPosts = new List<ParliamentaryPost>();

            foreach (XmlNode node in parliamentaryPostElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("ParliamentaryPost_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;
                var parliamentaryRankId = Convert.ToInt32(node.SelectSingleNode("ParliamentaryRank_Id").InnerText);
                var promoted = Convert.ToBoolean(node.SelectSingleNode("Promoted").InnerText);
                var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                DateTime? endDate = null;
                if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                    endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                var isCommons = Convert.ToBoolean(node.SelectSingleNode("IsCommons").InnerText);
                var isLords = Convert.ToBoolean(node.SelectSingleNode("IsLords").InnerText);
                var hansardName = node.SelectSingleNode("HansardName").InnerText;

                parliamentaryPosts.Add(new ParliamentaryPost
                {
                    Id = id,
                    Name = name,
                    ParliamentaryRankId = parliamentaryRankId,
                    Promoted = promoted,
                    StartDate = startDate,
                    EndDate = endDate,
                    IsCommons = isCommons,
                    IsLords = isLords,
                    HansardName = hansardName
                });
            }

            _dataImportRepository.AddParliamentaryPosts(parliamentaryPosts);
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
