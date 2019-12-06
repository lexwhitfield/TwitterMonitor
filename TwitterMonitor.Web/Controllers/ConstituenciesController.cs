using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Services.Services;
using TwitterMonitor.ViewModels.ViewModels;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/constituencies")]
    [Produces("application/json")]
    public class ConstituenciesController : ControllerBase
    {
        private readonly IConstituencyService _constituencyService;
        private readonly ILookupService _lookupService;

        public ConstituenciesController()
        {
            _constituencyService = new ConstituencyService();
            _lookupService = new LookupService();
        }

        [HttpGet]
        public IEnumerable<ConstituencyViewModel> GetAll(string name, int? constituencyTypeId, int? areaId, int? partyId, bool? current)
        {
            return _constituencyService.GetAll(name, constituencyTypeId, areaId, partyId, current);
        }

        [HttpGet]
        [Route("getareas")]
        public IEnumerable<KeyValueViewModel> GetAreas()
        {
            return _constituencyService.GetAreas();
        }

        [HttpGet]
        [Route("getconstituencytypes")]
        public IEnumerable<KeyValueViewModel> GetConstituencyTypes()
        {
            return _constituencyService.GetConstituencyTypes();
        }
    }
}
