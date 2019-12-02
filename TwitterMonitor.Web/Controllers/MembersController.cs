using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.Services;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.ViewModels.ViewModels;

namespace WebApp.Controllers
{
    [Route("api/members")]
    [Produces("application/json")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly TwitterService _twitterService;

        public MembersController()
        {
            _memberService = new MemberService();
            _twitterService = new TwitterService();
        }

        [HttpGet]
        public async Task<IEnumerable<MemberViewModel>> GetAll(string name, int? partyId, string constituencyName)
        {
            return await _memberService.GetAll(name, partyId, constituencyName);
        }
    }
}
