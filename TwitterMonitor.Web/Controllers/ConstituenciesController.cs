using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterMonitor.DataAccess;
using TwitterMonitor.DataModels;
using TwitterMonitor.ViewModels;
using TwitterMonitor.Transform;


namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/constituencies")]
    [Produces("application/json")]
    public class ConstituenciesController : ControllerBase
    {
        private readonly MemberDBContext _context;
        private readonly IDataRepository<Constituency> _repo;

        public ConstituenciesController(IDataRepository<Constituency> repo)
        {
            _context = new MemberDBContext();
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<ConstituencyViewModel> GetConstituencies()
        {
            var constituencies = _context.Constituency
                .Include(c => c.Authority)
                .Include(c => c.Authority.Region)
                .Include(c => c.Authority.Region.Country)
                .OrderBy(c => c.Name)
                .Select(ModelTransformer.ConstituencyToConstituencyViewModel).ToList();
            return constituencies;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConstituency([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var constituency = await _context.Constituency.FindAsync(id);

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
            var authorities = _context.Authority
                .OrderBy(a => a.Name)
                .Select(ModelTransformer.AuthorityToKeyValueViewModel).ToList();
            return authorities;
        }

        [HttpGet]
        [Route("getregions")]
        public IEnumerable<KeyValueViewModel> GetRegions()
        {
            var regions = _context.Region
                .OrderBy(r => r.Name)
                .Select(ModelTransformer.RegionToKeyValueViewModel).ToList();
            return regions;
        }

        [HttpGet]
        [Route("getcountries")]
        public IEnumerable<KeyValueViewModel> GetCountries()
        {
            var countries = _context.Country
                .OrderBy(c => c.Id)
                .Select(ModelTransformer.CountryToKeyValueViewModel).ToList();
            return countries;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstituency([FromRoute] int id, [FromBody] Constituency constituency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != constituency.Id)
            {
                return BadRequest();
            }

            _context.Entry(constituency).State = EntityState.Modified;

            try
            {
                _repo.Update(constituency);
                var save = await _repo.SaveAsync(constituency);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstituencyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostConstituency([FromBody] Constituency constituency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Add(constituency);
            var save = await _repo.SaveAsync(constituency);

            return CreatedAtAction("GetConstituency", new { id = save.Id }, save);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstituency([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var constituency = await _context.Constituency.FindAsync(id);
            if (constituency == null)
            {
                return NotFound();
            }

            _repo.Delete(constituency);
            var save = await _repo.SaveAsync(constituency);

            return Ok(save);
        }

        private bool ConstituencyExists(int id)
        {
            return _context.Constituency.Any(e => e.Id == id);
        }
    }
}
