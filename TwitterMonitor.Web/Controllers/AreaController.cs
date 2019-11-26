using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Services.Services;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Web.Controllers
{
    [ApiController]
    [Route("api/area")]
    [Produces("application/json")]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreaController()
        {
            _areaService = new AreaService();
        }

        [HttpGet]
        public IEnumerable<AreaViewModel> GetAreas(string name, int? areaTypeId)
        {
            return _areaService.GetAll().Result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArea([FromRoute] int id)
        {
            return Ok(await _areaService.GetById(id));
        }

        [HttpGet]
        [Route("importareas")]
        public bool ImportAreas()
        {
            return _areaService.ImportAreas().Result;
        }

        [HttpGet]
        [Route("getareatypes")]
        public async Task<IEnumerable<KeyValueViewModel>> GetAreaTypes()
        {
            return await _areaService.GetAreaTypes();
        }
    }
}