using Microsoft.AspNetCore.Mvc;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Services.Services;

namespace TwitterMonitor.Web.Controllers
{
    [Route("api/events")]
    [ApiController]
    [Produces("application/json")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController()
        {
            _eventService = new EventService();
        }
    }
}