using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterMonitor.Services.Services;

namespace TwitterMonitor.Web.Controllers
{
    [Route("api/conversion")]
    [ApiController]
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
            service.ConvertCountriesSqlServerToSqlite();

            service.ConvertRegionsSqlServerToSqlite();

            service.ConvertAuthoritiesSqlServerToSqlite();

            service.ConvertConstituenciesSqlServerToSqlite();

            service.ConvertPartiesSqlServerToSqlite();

            service.ConvertEventsSqlServerToSqlite();

            service.ConvertTwitterUsersSqlServerToSqlite();

            service.ConvertMembersSqlServerToSqlite();
        }
    }
}