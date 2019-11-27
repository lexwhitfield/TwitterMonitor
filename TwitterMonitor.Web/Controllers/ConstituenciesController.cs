using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwitterMonitor.ViewModels;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Services.Services;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<ConstituencyViewModel> GetConstituencies(string name, int? authorityId, int? regionId, int? countryId)
        {
            var constituencies = _constituencyService.GetAll(name, authorityId, regionId, countryId).Result;
            return constituencies;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConstituency([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var constituency = await _constituencyService.GetById(id);

            if (constituency == null)
            {
                return NotFound();
            }

            return Ok(constituency);
        }

        [HttpGet]
        [Route("getauthorities")]
        public IEnumerable<KeyValueViewModel> GetAuthorities()
        {
            var authorities = _lookupService.GetAuthorities().Result;
            return authorities;
        }

        [HttpGet]
        [Route("getregions")]
        public IEnumerable<KeyValueViewModel> GetRegions()
        {
            var regions = _lookupService.GetRegions().Result;
            return regions;
        }

        [HttpGet]
        [Route("getcountries")]
        public IEnumerable<KeyValueViewModel> GetCountries()
        {
            var countries = _lookupService.GetCountries().Result;
            return countries;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstituency([FromRoute] int id, [FromBody] ConstituencyViewModel constituency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != constituency.Id)
            {
                return BadRequest();
            }

            try
            {
                var save = await _constituencyService.Update(constituency);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostConstituency([FromBody] ConstituencyViewModel constituency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var save = await _constituencyService.Add(constituency);

            return CreatedAtAction("GetConstituency", new { id = save.Id }, save);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstituency([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var save = await _constituencyService.Delete(id);

            return Ok(save);
        }

        [HttpGet]
        [Route("importconstituencies")]
        public void ImportConstituencies()
        {
            _constituencyService.ImportConstituencies();
        }
    }
}
