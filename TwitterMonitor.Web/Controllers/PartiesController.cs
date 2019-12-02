using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.Services;
using TwitterMonitor.ViewModels;
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
        public IEnumerable<PartyViewModel> GetAll()
        {
            return _partyService.GetAll().Result;
        }
    }
}
