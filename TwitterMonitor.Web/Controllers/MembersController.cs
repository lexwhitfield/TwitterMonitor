using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.DataModel;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Route("api/members")]
    [Produces("application/json")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly MemberService _service;

        public MembersController(IDataRepository<Member> repo, IDataRepository<TwitterUser> _tweet, IDataRepository<TwitterStats> _stats)
        {
            _service = new MemberService(repo, _tweet, _stats);
        }

        [HttpGet]
        public IEnumerable<MemberViewModel> GetMembers(int? id, string name, int? partyId, string constituency, string twitterName)
        {
            return _service.GetAllMembers(id, name, partyId, constituency, twitterName);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var member = await _service.GetMemberById(id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember([FromRoute] int id, [FromBody] MemberViewModel member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != member.Id)
            {
                return BadRequest();
            }

            try
            {
                var updatedMember = await _service.UpdateMember(member);
                return Ok(updatedMember);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostMember(MemberViewModel member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newMember = await _service.AddMember(member);

            return Ok(newMember);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deletedMember = await _service.DeleteMember(id);

            return Ok(deletedMember);
        }
    }
}
