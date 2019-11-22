using Microsoft.AspNetCore.Mvc;
using TwitterMonitor.Services.Services;

namespace TwitterMonitor.Web.Controllers
{
    [Route("api/conversion")]
    [ApiController]
    [Produces("application/json")]
    public class ConversionController : ControllerBase
    {
        private readonly DataConvertService service;

        public ConversionController()
        {
            service = new DataConvertService();
        }

        [HttpGet]
        public void ConvertData()
        {
            //service.ConvertCountriesSqlServerToSqlite();

            //service.ConvertRegionsSqlServerToSqlite();

            //service.ConvertAuthoritiesSqlServerToSqlite();

            //service.ConvertConstituenciesSqlServerToSqlite();

            //service.ConvertPartiesSqlServerToSqlite();

            //service.ConvertEventsSqlServerToSqlite();

            //service.ConvertTwitterUsersSqlServerToSqlite();

            //service.ConvertMembersSqlServerToSqlite();
        }
    }
}