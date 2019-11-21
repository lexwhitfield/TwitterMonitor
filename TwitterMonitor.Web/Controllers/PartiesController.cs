using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterMonitor.DataAccess;
using TwitterMonitor.DataModels;
using TwitterMonitor.Services;
using TwitterMonitor.ViewModels;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/parties")]
    [Produces("application/json")]
    public class PartiesController : ControllerBase
    {
        private readonly MemberDBContext _context;
        private readonly IDataRepository<Party> _repo;

        private readonly PartyService _partyService;

        public PartiesController(IDataRepository<Party> repo)
        {
            _context = new MemberDBContext();
            _repo = repo;

            _partyService = new PartyService();
        }

        [HttpGet]
        public IEnumerable<PartyViewModel> GetParties()
        {
            var parties = _partyService.GetAll().Result.ToList();
            return parties;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var party = await _partyService.GetById(id);

            if (party == null)
            {
                return NotFound();
            }

            return Ok(party);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutParty([FromRoute] int id, [FromBody] PartyViewModel party)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != party.Id)
            {
                return BadRequest();
            }

            try
            {
                var save = await _partyService.Update(party);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostParty([FromBody] PartyViewModel party)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var save = await _partyService.Add(party);
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

            var save = await _partyService.Delete(id);

            return Ok(save);
        }
    }
}
