using Entities.DTO;
using LibraryProject.DAL.Models;
using LibraryProjectService;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    public class EventsController : Controller
    {

        private IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService= eventService;
        }

        [HttpGet]
        [Route("getAllEvents")]
        public List<EventDTO> GetAllEvents()
        {
            return _eventService.GetAllEvents();
        }
    }
}
