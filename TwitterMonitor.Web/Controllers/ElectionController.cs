using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Services.Services;
using TwitterMonitor.ViewModels.ViewModels;

namespace TwitterMonitor.Web.Controllers
{
    [ApiController]
    [Route("api/elections")]
    [Produces("application/json")]
    public class ElectionController : ControllerBase
    {
        private readonly IElectionService _electionService;

        public ElectionController()
        {
            _electionService = new ElectionService();
        }

        [HttpGet]
        public IEnumerable<ElectionViewModel> GetAll(int? electionTypeId)
        {
            return _electionService.GetAll(electionTypeId);
        }

        [HttpGet]
        [Route("getelectiontypes")]
        public IEnumerable<KeyValueViewModel> GetElectionTypes()
        {
            return _electionService.GetElectionTypes();
        }
    }
}