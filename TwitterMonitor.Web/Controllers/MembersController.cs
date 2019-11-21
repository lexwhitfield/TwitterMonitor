using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterMonitor.Services;
using TwitterMonitor.ViewModels;

namespace WebApp.Controllers
{
    [Route("api/members")]
    [Produces("application/json")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly MemberService _memberService;
        private readonly TwitterService _twitterService;

        public MembersController()
        {
            _memberService = new MemberService();
            _twitterService = new TwitterService();
        }

        [HttpGet]
        public IEnumerable<MemberViewModel> GetMembers(int? id, string name, int? partyId, string constituency, string twitterName)
        {
            return _memberService.GetAllMembers(id, name, partyId, constituency, twitterName).Result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var member = await _memberService.GetMemberById(id);

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
                await _twitterService.NewOrUpdatedTwitterDetails(member.TwitterScreenName, member.TwitterId);
                var updatedMember = await _memberService.UpdateMember(member);
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

            await _twitterService.NewOrUpdatedTwitterDetails(member.TwitterScreenName, null);
            var newMember = await _memberService.AddMember(member);

            return Ok(newMember);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deletedMember = await _memberService.DeleteMember(id);

            return Ok(deletedMember);
        }
    }
}
