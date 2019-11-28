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

        }

        [HttpGet]
        [Route("importdata")]
        public void ImportData()
        {

        }

        [HttpGet]
        [Route("importjoins")]
        public void ImportJoins()
        {

        }
    }
}