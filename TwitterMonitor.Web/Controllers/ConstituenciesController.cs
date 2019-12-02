using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Services.Services;
using TwitterMonitor.ViewModels;

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

    }
}
