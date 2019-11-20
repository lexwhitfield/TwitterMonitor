using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.DataModel;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/parties")]
    [Produces("application/json")]
    public class PartiesController : ControllerBase
    {
        private readonly MemberDBContext _context;
        private readonly IDataRepository<Party> _repo;

        public PartiesController(IDataRepository<Party> repo)
        {
            _context = new MemberDBContext();
            _repo = repo;
        }

        [HttpGet]
        [Route("")]
        [EnableCors("CorsPolicy")]
        public IEnumerable<Party> GetParties()
        {
            var parties = _context.Party.OrderBy(p => p.Name).ToList();
            return parties;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var party = await _context.Party.FindAsync(id);

            if (party == null)
            {
                return NotFound();
            }

            return Ok(party);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutParty([FromRoute] int id, [FromBody] Party party)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != party.Id)
            {
                return BadRequest();
            }

            _context.Entry(party).State = EntityState.Modified;

            try
            {
                _repo.Update(party);
                var save = await _repo.SaveAsync(party);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyExists(id))
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
        public async Task<IActionResult> PostParty([FromBody] Party party)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _repo.Add(party);
                var save = await _repo.SaveAsync(party);

                return CreatedAtAction("GetParty", new { id = save.Id }, save);
            }
            catch (Exception ex)
            {
                return base.Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var party = await _context.Party.FindAsync(id);
            if (party == null)
            {
                return NotFound();
            }

            _repo.Delete(party);
            var save = await _repo.SaveAsync(party);

            return Ok(save);
        }

        private bool PartyExists(int id)
        {
            return _context.Party.Any(e => e.Id == id);
        }
    }
}
