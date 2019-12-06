using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterMonitor.Services;
using TwitterMonitor.ViewModels.ViewModels;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/parties")]
    [Produces("application/json")]
    public class PartiesController : ControllerBase
    {
        private readonly PartyService _partyService;

        public PartiesController()
        {
            _partyService = new PartyService();
        }

        [HttpGet]
        public IEnumerable<PartyViewModel> GetAll(string name, bool withMembers = false, bool withActiveMembers = false)
        {
            return _partyService.GetAll(name, withMembers, withActiveMembers).Result;
        }
    }
}
