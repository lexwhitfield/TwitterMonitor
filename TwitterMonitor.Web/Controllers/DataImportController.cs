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
        [Route("importreferences")]
        public void ImportReferences()
        {
            _dataImportService.ImportReferences();
        }

        [HttpGet]
        [Route("importdata")]
        public void ImportData()
        {
            _dataImportService.ImportData();
        }

        [HttpGet]
        [Route("updatedata")]
        public void UpdateData()
        {
            _dataImportService.UpdateData();
        }

        [HttpGet]
        [Route("importjoins")]
        public void ImportJoins()
        {
            _dataImportService.ImportJoins();
        }

        [HttpGet]
        [Route("importmembers")]
        public void ImportMembers()
        {
            _dataImportService.ImportMembers();
        }

        [HttpGet]
        [Route("importtwitter")]
        public void ImportTwitter()
        {
            _dataImportService.ImportTwitter();
        }
    }
}