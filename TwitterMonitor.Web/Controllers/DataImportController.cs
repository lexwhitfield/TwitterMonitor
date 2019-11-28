using Microsoft.AspNetCore.Mvc;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Services.Services;

namespace TwitterMonitor.Web.Controllers
{
    [ApiController]
    [Route("api/import")]
    [Produces("application/json")]
    public class DataImportController : ControllerBase
    {
        private readonly IDataImportService _dataImportService;

        public DataImportController()
        {
            _dataImportService = new DataImportService();
        }

        [HttpGet]
        [Route("importareas")]
        public void ImportAreas()
        {
            _dataImportService.ImportAreas();
        }

        [HttpGet]
        [Route("importconstituencies")]
        public void ImportConstituencies()
        {
            _dataImportService.ImportConstituencies();
        }

        [HttpGet]
        [Route("importconstituencyareas")]
        public void ImportConstituencyAreas()
        {
            _dataImportService.ImportConstituencyAreas();
        }

        [HttpGet]
        [Route("importparties")]
        public void ImportParties()
        {
            _dataImportService.ImportParties();
        }

        [HttpGet]
        [Route("importmembers")]
        public void ImportMembers()
        {

        }

        [HttpGet]
        [Route("importcommittees")]
        public void ImportCommittees()
        {

        }

        [HttpGet]
        [Route("importgovernmentpositions")]
        public void ImportGovernmentPositions()
        {

        }

        [HttpGet]
        [Route("importoppositionpositions")]
        public void ImportOppositionPositions()
        {

        }

        [HttpGet]
        [Route("importparliamentaryposts")]
        public void ImportParliamentaryPosts()
        {

        }

        [HttpGet]
        [Route("importhonours")]
        public void ImportHonours()
        {

        }
    }
}