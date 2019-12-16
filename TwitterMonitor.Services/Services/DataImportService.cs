using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Tweetinvi;
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
                new Gender{ Id = 1, Name = "Male" },
                new Gender{ Id = 2, Name = "Female" },
                new Gender{ Id = 3, Name = "Other" }
            };

            _dataImportRepository.AddGenders(genders);

            // houses
            List<House> houses = new List<House>()
            {
                new House{ Id = 1, Name = "Commons" },
                new House{ Id = 2, Name = "Lords" }
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
                var oppositionRankId = ToNullableInt(node.SelectSingleNode("OppositionRank_Id").InnerText);
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
                var parliamentaryRankId = ToNullableInt(node.SelectSingleNode("ParliamentaryRank_Id").InnerText);
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
            // areas -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Areas/

            var areaElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Areas/", "Area");
            List<Area> areas = new List<Area>();

            foreach (XmlNode node in areaElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("Area_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;
                var onsAreaId = node.SelectSingleNode("OnsAreaId").InnerText;
                var areaTypeId = Convert.ToInt32(node.SelectSingleNode("AreaType_Id").InnerText);

                areas.Add(new Area
                {
                    Id = id,
                    Name = name,
                    OnsId = onsAreaId,
                    AreaTypeId = areaTypeId
                });
            }

            _dataImportRepository.AddAreas(areas);

            // constituencies -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Constituencies/

            var constituencyElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Constituencies/", "Constituency");
            List<Constituency> constituencies = new List<Constituency>();

            foreach (XmlNode node in constituencyElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("Constituency_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;
                var constituencyTypeId = ToNullableInt(node.SelectSingleNode("ConstituencyType_Id").InnerText);
                var prevConstituencyId = node.SelectSingleNode("PrevConstituencyId").InnerText;
                var oldDodsId = ToNullableInt(node.SelectSingleNode("OldDodsId").InnerText);
                var oldDisId = ToNullableInt(node.SelectSingleNode("OldDisId").InnerText);
                var clerksConstituencyId = ToNullableInt(node.SelectSingleNode("ClerksConstituencyId").InnerText);
                var gisId = ToNullableInt(node.SelectSingleNode("GisId").InnerText);
                var pcaCode = ToNullableInt(node.SelectSingleNode("PcaCode").InnerText);
                var pconName = node.SelectSingleNode("PconName").InnerText;
                var osName = node.SelectSingleNode("OsName").InnerText;
                var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                DateTime? endDate = null;
                if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                    endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                var onsCode = node.SelectSingleNode("ONSCode").InnerText;
                var schoolSubsidyBand = node.SelectSingleNode("SchoolsSubsidyBand").InnerText;

                constituencies.Add(new Constituency
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
                    SchoolsSubsidyBand = schoolSubsidyBand
                });
            }

            _dataImportRepository.AddConstituencies(constituencies);

            // elections -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Elections/

            var electionElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Elections/", "Election");
            List<Election> elections = new List<Election>();

            foreach (XmlNode node in electionElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("Election_Id").InnerText);
                var electionTypeId = Convert.ToInt32(node.SelectSingleNode("ElectionType_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;
                var electionDate = Convert.ToDateTime(node.SelectSingleNode("ElectionDate").InnerText);

                elections.Add(new Election
                {
                    Id = id,
                    Name = name,
                    ElectionTypeId = electionTypeId,
                    ElectionDate = electionDate
                });
            }

            _dataImportRepository.AddElections(elections);

            // parties -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Parties/

            var partyElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Parties/", "Party");
            List<Party> parties = new List<Party>();

            foreach (XmlNode node in partyElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("Party_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;
                var abbr = node.SelectSingleNode("Abbreviation").InnerText;
                var initials = node.SelectSingleNode("Initials").InnerText;
                var colour = node.SelectSingleNode("Colour").InnerText;
                var textColour = node.SelectSingleNode("TextColour").InnerText;
                var isCommons = Convert.ToBoolean(node.SelectSingleNode("IsCommons").InnerText);
                var isLords = Convert.ToBoolean(node.SelectSingleNode("IsLords").InnerText);
                var oldDisId = ToNullableInt(node.SelectSingleNode("OldDISId").InnerText);
                var holMainParty = Convert.ToBoolean(node.SelectSingleNode("HoLMainParty").InnerText);
                var holOrder = ToNullableInt(node.SelectSingleNode("HoLOrder").InnerText);
                var holIsSpiritualSide = Convert.ToBoolean(node.SelectSingleNode("HoL_IsSpiritualSide").InnerText);

                parties.Add(new Party
                {
                    Id = id,
                    Name = name,
                    Abbr = abbr,
                    Initials = initials,
                    Colour = colour,
                    TextColour = textColour,
                    IsCommons = isCommons,
                    IsLords = isLords,
                    OldDisId = oldDisId,
                    HoLMainParty = holMainParty,
                    HoLOrder = holOrder,
                    HoLIsSpiritualSide = holIsSpiritualSide
                });
            }

            _dataImportRepository.AddParties(parties);

            // committees -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Committees/

            var committeeElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Committees/", "Committee");
            List<Committee> committees = new List<Committee>();

            foreach (XmlNode node in committeeElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("Committee_Id").InnerText);
                var committeeTypeId = Convert.ToInt32(node.SelectSingleNode("CommitteeType_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;
                var parentCommitteeId = ToNullableInt(node.SelectSingleNode("ParentCommittee_Id").InnerText);
                DateTime? dateLordsAppointed = null;
                if (!string.IsNullOrEmpty(node.SelectSingleNode("DateLordsAppointed").InnerText))
                    dateLordsAppointed = Convert.ToDateTime(node.SelectSingleNode("DateLordsAppointed").InnerText);
                DateTime? dateCommonsAppointed = null;
                if (!string.IsNullOrEmpty(node.SelectSingleNode("DateCommonsAppointed").InnerText))
                    dateCommonsAppointed = Convert.ToDateTime(node.SelectSingleNode("DateCommonsAppointed").InnerText);
                DateTime startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                DateTime? endDate = null;
                if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                    endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                var createdFromCommitteeId = ToNullableInt(node.SelectSingleNode("CreatedFromCommittee_Id").InnerText);
                var isCommons = Convert.ToBoolean(node.SelectSingleNode("IsCommons").InnerText);
                var isLords = Convert.ToBoolean(node.SelectSingleNode("IsLords").InnerText);

                committees.Add(new Committee
                {
                    Id = id,
                    Name = name,
                    CommitteeTypeId = committeeTypeId,
                    ParentCommitteeId = parentCommitteeId,
                    DateLordsAppointed = dateLordsAppointed,
                    DateCommonsAppointed = dateCommonsAppointed,
                    StartDate = startDate,
                    EndDate = endDate,
                    CreatedFromCommitteeId = createdFromCommitteeId,
                    IsCommons = isCommons,
                    IsLords = isLords
                });
            }

            _dataImportRepository.AddCommittees(committees);
        }

        public async void UpdateData()
        {
            // elections -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Elections/

            var existingElectionIds = _dataImportRepository.GetElectionIds().Result;
            var electionElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Elections/", "Election");
            List<Election> elections = new List<Election>();

            foreach (XmlNode node in electionElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("Election_Id").InnerText);

                if (existingElectionIds.Contains(id) || id == 0)
                    continue;

                var electionTypeId = Convert.ToInt32(node.SelectSingleNode("ElectionType_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;
                var electionDate = Convert.ToDateTime(node.SelectSingleNode("ElectionDate").InnerText);

                elections.Add(new Election
                {
                    Id = id,
                    Name = name,
                    ElectionTypeId = electionTypeId,
                    ElectionDate = electionDate
                });
            }

            if (elections.Count > 0)
                _dataImportRepository.AddElections(elections);

            // parties -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Parties/

            var existingPartyIds = _dataImportRepository.GetPartyIds().Result;
            var partyElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Parties/", "Party");
            List<Party> parties = new List<Party>();

            foreach (XmlNode node in partyElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("Party_Id").InnerText);

                if (existingPartyIds.Contains(id))
                    continue;

                var name = node.SelectSingleNode("Name").InnerText;
                var abbr = node.SelectSingleNode("Abbreviation").InnerText;
                var initials = node.SelectSingleNode("Initials").InnerText;
                var colour = node.SelectSingleNode("Colour").InnerText;
                var textColour = node.SelectSingleNode("TextColour").InnerText;
                var isCommons = Convert.ToBoolean(node.SelectSingleNode("IsCommons").InnerText);
                var isLords = Convert.ToBoolean(node.SelectSingleNode("IsLords").InnerText);
                var oldDisId = ToNullableInt(node.SelectSingleNode("OldDISId").InnerText);
                var holMainParty = Convert.ToBoolean(node.SelectSingleNode("HoLMainParty").InnerText);
                var holOrder = ToNullableInt(node.SelectSingleNode("HoLOrder").InnerText);
                var holIsSpiritualSide = Convert.ToBoolean(node.SelectSingleNode("HoL_IsSpiritualSide").InnerText);

                parties.Add(new Party
                {
                    Id = id,
                    Name = name,
                    Abbr = abbr,
                    Initials = initials,
                    Colour = colour,
                    TextColour = textColour,
                    IsCommons = isCommons,
                    IsLords = isLords,
                    OldDisId = oldDisId,
                    HoLMainParty = holMainParty,
                    HoLOrder = holOrder,
                    HoLIsSpiritualSide = holIsSpiritualSide
                });
            }

            if (parties.Count > 0)
                _dataImportRepository.AddParties(parties);

            // committees -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Committees/

            var existingCommitteeIds = _dataImportRepository.GetCommitteeIds().Result;
            var committeeElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/Committees/", "Committee");
            List<Committee> committees = new List<Committee>();

            foreach (XmlNode node in committeeElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("Committee_Id").InnerText);

                if (existingCommitteeIds.Contains(id))
                    continue;

                var committeeTypeId = Convert.ToInt32(node.SelectSingleNode("CommitteeType_Id").InnerText);
                var name = node.SelectSingleNode("Name").InnerText;
                var parentCommitteeId = ToNullableInt(node.SelectSingleNode("ParentCommittee_Id").InnerText);
                DateTime? dateLordsAppointed = null;
                if (!string.IsNullOrEmpty(node.SelectSingleNode("DateLordsAppointed").InnerText))
                    dateLordsAppointed = Convert.ToDateTime(node.SelectSingleNode("DateLordsAppointed").InnerText);
                DateTime? dateCommonsAppointed = null;
                if (!string.IsNullOrEmpty(node.SelectSingleNode("DateCommonsAppointed").InnerText))
                    dateCommonsAppointed = Convert.ToDateTime(node.SelectSingleNode("DateCommonsAppointed").InnerText);
                DateTime startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                DateTime? endDate = null;
                if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                    endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                var createdFromCommitteeId = ToNullableInt(node.SelectSingleNode("CreatedFromCommittee_Id").InnerText);
                var isCommons = Convert.ToBoolean(node.SelectSingleNode("IsCommons").InnerText);
                var isLords = Convert.ToBoolean(node.SelectSingleNode("IsLords").InnerText);

                committees.Add(new Committee
                {
                    Id = id,
                    Name = name,
                    CommitteeTypeId = committeeTypeId,
                    ParentCommitteeId = parentCommitteeId,
                    DateLordsAppointed = dateLordsAppointed,
                    DateCommonsAppointed = dateCommonsAppointed,
                    StartDate = startDate,
                    EndDate = endDate,
                    CreatedFromCommitteeId = createdFromCommitteeId,
                    IsCommons = isCommons,
                    IsLords = isLords
                });
            }

            if (committees.Count > 0)
                _dataImportRepository.AddCommittees(committees);
        }

        public async void ImportJoins()
        {
            // constituency areas -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ConstituencyAreas/

            var constituencyAreaElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/ConstituencyAreas/", "ConstituencyArea");
            List<ConstituencyArea> constituencyAreas = new List<ConstituencyArea>();

            foreach (XmlNode node in constituencyAreaElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("ConstituencyAreas_Id").InnerText);
                var constituencyId = Convert.ToInt32(node.SelectSingleNode("Constituency_Id").InnerText);
                var areaId = Convert.ToInt32(node.SelectSingleNode("Area_Id").InnerText);
                var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                DateTime? endDate = null;
                if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                    endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                constituencyAreas.Add(new ConstituencyArea
                {
                    Id = id,
                    ConstituencyId = constituencyId,
                    AreaId = areaId,
                    StartDate = startDate,
                    EndDate = endDate
                });
            }

            _dataImportRepository.AddConstituencyAreas(constituencyAreas);

            // government post departments -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/GovernmentPostDepartments/    

            var governmentPostDepartmentElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/GovernmentPostDepartments/", "GovernmentPostDepartment");
            List<GovernmentPostDepartment> governmentPostDepartments = new List<GovernmentPostDepartment>();

            foreach (XmlNode node in governmentPostDepartmentElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("GovernmentPostDepartment_Id").InnerText);
                var governmentPostId = Convert.ToInt32(node.SelectSingleNode("GovernmentPost_Id").InnerText);
                var departmentId = Convert.ToInt32(node.SelectSingleNode("Department_Id").InnerText);

                governmentPostDepartments.Add(new GovernmentPostDepartment
                {
                    Id = id,
                    GovernmentPostId = governmentPostId,
                    DepartmentId = departmentId
                });
            }

            _dataImportRepository.AddGovernmentPostDepartments(governmentPostDepartments);

            // opposition post departments -- http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/OppositionPostDepartments/

            var oppositionPostDepartmentElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/ReferenceData/OppositionPostDepartments/", "OppositionPostDepartment");
            List<OppositionPostDepartment> oppositionPostDepartments = new List<OppositionPostDepartment>();

            foreach (XmlNode node in oppositionPostDepartmentElements)
            {
                var id = Convert.ToInt32(node.SelectSingleNode("OppositionPostDepartment_Id").InnerText);
                var oppositionPostId = Convert.ToInt32(node.SelectSingleNode("OppositionPost_Id").InnerText);
                var departmentId = Convert.ToInt32(node.SelectSingleNode("Department_Id").InnerText);

                oppositionPostDepartments.Add(new OppositionPostDepartment
                {
                    Id = id,
                    OppositionPostId = oppositionPostId,
                    DepartmentId = departmentId
                });
            }

            _dataImportRepository.AddOppositionPostDepartments(oppositionPostDepartments);
        }

        public async void ImportMembers()
        {
            // members -- http://data.parliament.uk/membersdataplatform/services/mnis/members/query/House=Commons|Membership=all/

            var existingMemberIds = _dataImportRepository.GetMemberIds().Result;
            var memberIdElements = await GetXmlElements("http://data.parliament.uk/membersdataplatform/services/mnis/members/query/House=Commons|Membership=all/", "Member");
            List<int> oldMemberIds = new List<int>();
            List<int> newMemberIds = new List<int>();

            foreach (XmlNode node in memberIdElements)
            {
                var id = Convert.ToInt32(node.Attributes["Member_Id"].InnerText);

                if (existingMemberIds.Contains(id))
                    oldMemberIds.Add(id);
                else
                    newMemberIds.Add(id);
            }

            if (oldMemberIds.Count > 0)
                UpdateMembersDetails(oldMemberIds);

            if (newMemberIds.Count > 0)
                AddMembersDetails(newMemberIds);
        }

        private async void AddMembersDetails(List<int> ids)
        {
            List<Member> members = new List<Member>();
            List<ConstituencyMember> constituencies = new List<ConstituencyMember>();
            List<HouseMember> houseMembers = new List<HouseMember>();
            List<CommitteeMember> committees = new List<CommitteeMember>();
            List<GovernmentPostMember> governmentPostMembers = new List<GovernmentPostMember>();
            List<OppositionPostMember> oppositionPostMembers = new List<OppositionPostMember>();
            List<ParliamentaryPostMember> parliamentaryPostMembers = new List<ParliamentaryPostMember>();
            List<PartyMember> parties = new List<PartyMember>();
            List<TwitterUser> twitterUsers = new List<TwitterUser>();

            var titles = _dataImportRepository.GetTitles().Result;

            foreach (int memberId in ids)
            {
                var memberElement = (await GetXmlElements($"http://data.parliament.uk/membersdataplatform/services/mnis/members/query/id={memberId}/FullBiog", "Member")).Item(0);

                XmlNode preferredNameNode = memberElement.SelectSingleNode("PreferredNames").ChildNodes.Item(0);
                XmlNodeList houseMembershipsNodes = memberElement.SelectSingleNode("HouseMemberships").ChildNodes;
                XmlNodeList constituencyNodes = memberElement.SelectSingleNode("Constituencies").ChildNodes;
                XmlNodeList committeeNodes = memberElement.SelectSingleNode("Committees").ChildNodes;
                XmlNodeList governmentPostNodes = memberElement.SelectSingleNode("GovernmentPosts").ChildNodes;
                XmlNodeList oppositionPostNodes = memberElement.SelectSingleNode("OppositionPosts").ChildNodes;
                XmlNodeList parliamentaryPostNodes = memberElement.SelectSingleNode("ParliamentaryPosts").ChildNodes;
                XmlNodeList partyNodes = memberElement.SelectSingleNode("Parties").ChildNodes;
                XmlNodeList addressNodes = memberElement.SelectSingleNode("Addresses").ChildNodes;

                var dodsId = ToNullableInt(memberElement.Attributes["Dods_Id"].InnerText);
                var pimsId = ToNullableInt(memberElement.Attributes["Pims_Id"].InnerText);
                var clerksId = ToNullableInt(memberElement.Attributes["Clerks_Id"].InnerText);
                var title = preferredNameNode.SelectSingleNode("Title").InnerText;
                var titleId = titles.FirstOrDefault(t => t.Name.ToLower() == title.ToLower())?.Id;
                var forename = preferredNameNode.SelectSingleNode("Forename").InnerText;
                var surname = preferredNameNode.SelectSingleNode("Surname").InnerText;
                var gender = memberElement.SelectSingleNode("Gender").InnerText;
                var genderId = (gender == "M") ? 1 : 2;
                DateTime? dateOfBirth = null;
                if (!string.IsNullOrEmpty(memberElement.SelectSingleNode("DateOfBirth ").InnerText))
                    dateOfBirth = Convert.ToDateTime(memberElement.SelectSingleNode("DateOfBirth").InnerText);
                DateTime? dateOfDeath = null;
                if (!string.IsNullOrEmpty(memberElement.SelectSingleNode("DateOfDeath ").InnerText))
                    dateOfDeath = Convert.ToDateTime(memberElement.SelectSingleNode("DateOfDeath").InnerText);

                members.Add(new Member
                {
                    Id = memberId,
                    DodsId = dodsId,
                    PimsId = pimsId,
                    ClerksId = clerksId,
                    TitleId = titleId,
                    Forename = forename,
                    Surname = surname,
                    GenderId = genderId,
                    DateOfBirth = dateOfBirth,
                    DateOfDeath = dateOfDeath
                });

                // house members
                foreach (XmlNode node in houseMembershipsNodes)
                {
                    var house = node.SelectSingleNode("House").InnerText;
                    var houseId = (house == "Commons") ? 1 : 2;
                    var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                    DateTime? endDate = null;
                    if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                        endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                    var endReason = node.SelectSingleNode("EndReason").InnerText;
                    var endNotes = node.SelectSingleNode("EndNotes").InnerText;

                    houseMembers.Add(new HouseMember
                    {
                        HouseId = houseId,
                        MemberId = memberId,
                        StartDate = startDate,
                        EndDate = endDate,
                        EndReason = endReason,
                        EndNotes = endNotes
                    });
                }

                // constituency members
                foreach (XmlNode node in constituencyNodes)
                {
                    var constituencyId = Convert.ToInt32(node.Attributes["Id"].InnerText);
                    var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                    DateTime? endDate = null;
                    if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                        endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                    XmlNode electionNode = node.SelectSingleNode("Election");
                    var electionId = Convert.ToInt32(electionNode.Attributes["Id"].InnerText);

                    var endReason = node.SelectSingleNode("EndReason").InnerText;
                    var entryType = node.SelectSingleNode("EntryType").InnerText;

                    constituencies.Add(new ConstituencyMember
                    {
                        MemberId = memberId,
                        ConstituencyId = constituencyId,
                        StartDate = startDate,
                        EndDate = endDate,
                        ElectionId = electionId,
                        EndReason = endReason,
                        EntryType = entryType
                    });
                }

                // committee members
                foreach (XmlNode node in committeeNodes)
                {
                    var committeeId = Convert.ToInt32(node.Attributes["Id"].InnerText);
                    var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                    DateTime? endDate = null;
                    if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                        endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                    var endNote = node.SelectSingleNode("EndNote").InnerText;
                    var isExOfficio = Convert.ToBoolean(node.SelectSingleNode("IsExOfficio").InnerText);
                    var isAlternate = Convert.ToBoolean(node.SelectSingleNode("IsAlternate").InnerText);
                    var isCoOpted = Convert.ToBoolean(node.SelectSingleNode("IsCoOpted").InnerText);

                    committees.Add(new CommitteeMember
                    {
                        MemberId = memberId,
                        CommitteeId = committeeId,
                        StartDate = startDate,
                        EndDate = endDate,
                        EndNote = endNote,
                        IsExOfficio = isExOfficio,
                        IsAlternate = isAlternate,
                        IsCoOpted = isCoOpted
                    });
                }

                // government post members
                foreach (XmlNode node in governmentPostNodes)
                {
                    var governmentPostId = Convert.ToInt32(node.Attributes["Id"].InnerText);
                    var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                    DateTime? endDate = null;
                    if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                        endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                    governmentPostMembers.Add(new GovernmentPostMember
                    {
                        MemberId = memberId,
                        GovernmentPostId = governmentPostId,
                        StartDate = startDate,
                        EndDate = endDate
                    });
                }

                // opposition post members
                foreach (XmlNode node in oppositionPostNodes)
                {
                    var oppositionPostId = Convert.ToInt32(node.Attributes["Id"].InnerText);
                    var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                    DateTime? endDate = null;
                    if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                        endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                    oppositionPostMembers.Add(new OppositionPostMember
                    {
                        MemberId = memberId,
                        OppositionPostId = oppositionPostId,
                        StartDate = startDate,
                        EndDate = endDate
                    });
                }

                // parliamentary post members
                foreach (XmlNode node in parliamentaryPostNodes)
                {
                    var parliamentaryPostId = Convert.ToInt32(node.Attributes["Id"].InnerText);
                    var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                    DateTime? endDate = null;
                    if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                        endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                    parliamentaryPostMembers.Add(new ParliamentaryPostMember
                    {
                        MemberId = memberId,
                        ParliamentaryPostId = parliamentaryPostId,
                        StartDate = startDate,
                        EndDate = endDate
                    });
                }

                // party members
                foreach (XmlNode node in partyNodes)
                {
                    var partyId = Convert.ToInt32(node.Attributes["Id"].InnerText);
                    var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                    DateTime? endDate = null;
                    if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                        endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                    parties.Add(new PartyMember
                    {
                        MemberId = memberId,
                        PartyId = partyId,
                        StartDate = startDate,
                        EndDate = endDate
                    });
                }
            }

            _dataImportRepository.AddMembers(members);
            _dataImportRepository.AddConstituencyMembers(constituencies);
            _dataImportRepository.AddHouseMembers(houseMembers);
            _dataImportRepository.AddCommitteeMembers(committees);
            _dataImportRepository.AddGovernmentPostMembers(governmentPostMembers);
            _dataImportRepository.AddOppositionPostMembers(oppositionPostMembers);
            _dataImportRepository.AddParliamentaryPostMembers(parliamentaryPostMembers);
            _dataImportRepository.AddPartyMembers(parties);
        }

        private async void UpdateMembersDetails(List<int> ids)
        {
            var titles = _dataImportRepository.GetTitles().Result;

            foreach (int memberId in ids)
            {
                try
                {
                    List<ConstituencyMember> newConstituencyMembers = new List<ConstituencyMember>();
                    List<HouseMember> newHouseMembers = new List<HouseMember>();
                    List<CommitteeMember> newCommitteeMembers = new List<CommitteeMember>();
                    List<GovernmentPostMember> newGovernmentPostMembers = new List<GovernmentPostMember>();
                    List<OppositionPostMember> newOppositionPostMembers = new List<OppositionPostMember>();
                    List<ParliamentaryPostMember> newParliamentaryPostMembers = new List<ParliamentaryPostMember>();
                    List<PartyMember> newPartyMembers = new List<PartyMember>();

                    var memberElement = (await GetXmlElements($"http://data.parliament.uk/membersdataplatform/services/mnis/members/query/id={memberId}/FullBiog", "Member")).Item(0);

                    XmlNode preferredNameNode = memberElement.SelectSingleNode("PreferredNames").ChildNodes.Item(0);
                    XmlNodeList houseMembershipsNodes = memberElement.SelectSingleNode("HouseMemberships").ChildNodes;
                    XmlNodeList constituencyNodes = memberElement.SelectSingleNode("Constituencies").ChildNodes;
                    XmlNodeList committeeNodes = memberElement.SelectSingleNode("Committees").ChildNodes;
                    XmlNodeList governmentPostNodes = memberElement.SelectSingleNode("GovernmentPosts").ChildNodes;
                    XmlNodeList oppositionPostNodes = memberElement.SelectSingleNode("OppositionPosts").ChildNodes;
                    XmlNodeList parliamentaryPostNodes = memberElement.SelectSingleNode("ParliamentaryPosts").ChildNodes;
                    XmlNodeList partyNodes = memberElement.SelectSingleNode("Parties").ChildNodes;
                    XmlNodeList addressNodes = memberElement.SelectSingleNode("Addresses").ChildNodes;

                    var title = preferredNameNode.SelectSingleNode("Title").InnerText;
                    var titleId = titles.FirstOrDefault(t => t.Name.ToLower() == title.ToLower())?.Id;
                    var surname = preferredNameNode.SelectSingleNode("Surname").InnerText;
                    DateTime? dateOfDeath = null;
                    if (!string.IsNullOrEmpty(memberElement.SelectSingleNode("DateOfDeath ").InnerText))
                        dateOfDeath = Convert.ToDateTime(memberElement.SelectSingleNode("DateOfDeath").InnerText);

                    var member = _dataImportRepository.GetMember(memberId).Result;
                    member.TitleId = titleId;
                    member.Surname = surname;
                    member.DateOfDeath = dateOfDeath;

                    // house members
                    foreach (XmlNode node in houseMembershipsNodes)
                    {
                        var house = node.SelectSingleNode("House").InnerText;
                        var houseId = (house == "Commons") ? 1 : 2;

                        // already exists?
                        var houseMember = _dataImportRepository.GetHouseMember(memberId, houseId).Result;

                        if (houseMember == null)
                        {
                            var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                            var endReason = node.SelectSingleNode("EndReason").InnerText;
                            var endNotes = node.SelectSingleNode("EndNotes").InnerText;

                            newHouseMembers.Add(new HouseMember
                            {
                                HouseId = houseId,
                                MemberId = memberId,
                                StartDate = startDate,
                                EndDate = endDate,
                                EndReason = endReason,
                                EndNotes = endNotes
                            });
                        }
                        else
                        {
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                            var endReason = node.SelectSingleNode("EndReason").InnerText;
                            var endNotes = node.SelectSingleNode("EndNotes").InnerText;

                            houseMember.EndDate = endDate;
                            houseMember.EndReason = endReason;
                            houseMember.EndNotes = endNotes;
                        }
                    }

                    if (newHouseMembers.Count > 0)
                        _dataImportRepository.AddHouseMembers(newHouseMembers);

                    // constituency members
                    foreach (XmlNode node in constituencyNodes)
                    {
                        var constituencyId = Convert.ToInt32(node.Attributes["Id"].InnerText);
                        XmlNode electionNode = node.SelectSingleNode("Election");
                        var electionId = Convert.ToInt32(electionNode.Attributes["Id"].InnerText);                        

                        var constituencyMember = _dataImportRepository.GetConstituencyMember(memberId, constituencyId, electionId).Result;

                        if (constituencyMember == null)
                        {
                            var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                              

                            var endReason = node.SelectSingleNode("EndReason").InnerText;
                            var entryType = node.SelectSingleNode("EntryType").InnerText;

                            newConstituencyMembers.Add(new ConstituencyMember
                            {
                                MemberId = memberId,
                                ConstituencyId = constituencyId,
                                StartDate = startDate,
                                EndDate = endDate,
                                ElectionId = electionId,
                                EndReason = endReason,
                                EntryType = entryType
                            });
                        }
                        else
                        {
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                            var endReason = node.SelectSingleNode("EndReason").InnerText;

                            constituencyMember.EndDate = endDate;
                            constituencyMember.EndReason = endReason;
                        }
                    }

                    if (newConstituencyMembers.Count > 0)
                        _dataImportRepository.AddConstituencyMembers(newConstituencyMembers);

                    // committee members
                    foreach (XmlNode node in committeeNodes)
                    {
                        var committeeId = Convert.ToInt32(node.Attributes["Id"].InnerText);

                        var committeeMember = _dataImportRepository.GetCommitteeMember(memberId, committeeId).Result;

                        if (committeeMember == null)
                        {
                            var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                            var endNote = node.SelectSingleNode("EndNote").InnerText;
                            var isExOfficio = Convert.ToBoolean(node.SelectSingleNode("IsExOfficio").InnerText);
                            var isAlternate = Convert.ToBoolean(node.SelectSingleNode("IsAlternate").InnerText);
                            var isCoOpted = Convert.ToBoolean(node.SelectSingleNode("IsCoOpted").InnerText);

                            newCommitteeMembers.Add(new CommitteeMember
                            {
                                MemberId = memberId,
                                CommitteeId = committeeId,
                                StartDate = startDate,
                                EndDate = endDate,
                                EndNote = endNote,
                                IsExOfficio = isExOfficio,
                                IsAlternate = isAlternate,
                                IsCoOpted = isCoOpted
                            });
                        }
                        else
                        {
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);
                            var endNote = node.SelectSingleNode("EndNote").InnerText;
                            var isExOfficio = Convert.ToBoolean(node.SelectSingleNode("IsExOfficio").InnerText);
                            var isAlternate = Convert.ToBoolean(node.SelectSingleNode("IsAlternate").InnerText);
                            var isCoOpted = Convert.ToBoolean(node.SelectSingleNode("IsCoOpted").InnerText);

                            committeeMember.EndDate = endDate;
                            committeeMember.EndNote = endNote;
                            committeeMember.IsExOfficio = isExOfficio;
                            committeeMember.IsAlternate = isAlternate;
                            committeeMember.IsCoOpted = isCoOpted;
                        }
                    }

                    if (newCommitteeMembers.Count > 0)
                        _dataImportRepository.AddCommitteeMembers(newCommitteeMembers);

                    // government post members
                    foreach (XmlNode node in governmentPostNodes)
                    {
                        var governmentPostId = Convert.ToInt32(node.Attributes["Id"].InnerText);

                        var governmentPostMember = _dataImportRepository.GetGovernmentPostMember(memberId, governmentPostId).Result;

                        if (governmentPostMember == null)
                        {
                            var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                            newGovernmentPostMembers.Add(new GovernmentPostMember
                            {
                                MemberId = memberId,
                                GovernmentPostId = governmentPostId,
                                StartDate = startDate,
                                EndDate = endDate
                            });
                        }
                        else
                        {
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                            governmentPostMember.EndDate = endDate;
                        }
                    }

                    if (newGovernmentPostMembers.Count > 0)
                        _dataImportRepository.AddGovernmentPostMembers(newGovernmentPostMembers);

                    // opposition post members
                    foreach (XmlNode node in oppositionPostNodes)
                    {
                        var oppositionPostId = Convert.ToInt32(node.Attributes["Id"].InnerText);

                        var oppositionPostMember = _dataImportRepository.GetOppositionPostMember(memberId, oppositionPostId).Result;

                        if (oppositionPostMember == null)
                        {
                            var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                            newOppositionPostMembers.Add(new OppositionPostMember
                            {
                                MemberId = memberId,
                                OppositionPostId = oppositionPostId,
                                StartDate = startDate,
                                EndDate = endDate
                            });
                        }
                        else
                        {
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                            oppositionPostMember.EndDate = endDate;
                        }
                    }

                    if (newOppositionPostMembers.Count > 0)
                        _dataImportRepository.AddOppositionPostMembers(newOppositionPostMembers);

                    // parliamentary post members
                    foreach (XmlNode node in parliamentaryPostNodes)
                    {
                        var parliamentaryPostId = Convert.ToInt32(node.Attributes["Id"].InnerText);

                        var parliamentaryPostMember = _dataImportRepository.GetParliamentaryPostMember(memberId, parliamentaryPostId).Result;

                        if (parliamentaryPostMember == null)
                        {
                            var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                            newParliamentaryPostMembers.Add(new ParliamentaryPostMember
                            {
                                MemberId = memberId,
                                ParliamentaryPostId = parliamentaryPostId,
                                StartDate = startDate,
                                EndDate = endDate
                            });
                        }
                        else
                        {
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                            parliamentaryPostMember.EndDate = endDate;
                        }
                    }

                    if (newParliamentaryPostMembers.Count > 0)
                        _dataImportRepository.AddParliamentaryPostMembers(newParliamentaryPostMembers);

                    // party members
                    foreach (XmlNode node in partyNodes)
                    {
                        var partyId = Convert.ToInt32(node.Attributes["Id"].InnerText);

                        var partyMember = _dataImportRepository.GetPartyMember(memberId, partyId).Result;

                        if (partyMember == null)
                        {
                            var startDate = Convert.ToDateTime(node.SelectSingleNode("StartDate").InnerText);
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                            newPartyMembers.Add(new PartyMember
                            {
                                MemberId = memberId,
                                PartyId = partyId,
                                StartDate = startDate,
                                EndDate = endDate
                            });
                        }
                        else
                        {
                            DateTime? endDate = null;
                            if (!string.IsNullOrEmpty(node.SelectSingleNode("EndDate").InnerText))
                                endDate = Convert.ToDateTime(node.SelectSingleNode("EndDate").InnerText);

                            partyMember.EndDate = endDate;
                        }
                    }

                    if (newPartyMembers.Count > 0)
                        _dataImportRepository.AddPartyMembers(newPartyMembers);

                    _dataImportRepository.SaveUpdates();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }            
        }
        
        public async void ImportTwitter()
        {
            string consumerKey = "RDaLBut56yuG3lloMC2yjZIGv";
            string consumerSecret = "EsLEBBcQJppNFWbLfHx3Auh5F032OCpCEsQAVMQfckJeQsoDdw";
            string accessToken = "3135075776-KroVu87rgSFVfAWh3ALZkTlvCYlXuTIQHEAdbF9";
            string accessTokenSecret = "axHvrtykhYyRCGTA61GZMqg1gScIKznZjU3ROGdVEwAje";

            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);

            var memberIds = _dataImportRepository.GetMemberIds().Result;

            foreach (var id in memberIds)
            {
                var memberElement = (await GetXmlElements($"http://data.parliament.uk/membersdataplatform/services/mnis/members/query/id={id}/Addresses", "Member")).Item(0);

                var twitterElement = memberElement.SelectSingleNode("Addresses/Address[@Type_Id=7]");

                if (twitterElement != null)
                {
                    var twitterScreenName = twitterElement.SelectSingleNode("Address1").InnerText.Split('/').Last();

                    var user = User.GetUserFromScreenName(twitterScreenName);

                    if (user != null)
                    {
                        TwitterUser twitterUser = new TwitterUser
                        {
                            Id = user.Id,
                            ScreenName = twitterScreenName,
                            CreatedAt = user.CreatedAt
                        };

                        _dataImportRepository.AddTwitterUser(id, twitterUser);
                    }
                }
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
    }
}
