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
            _eventService = eventService;
        }

        [HttpGet]
        [Route("getAllEvents")]
        public List<EventDTO> GetAllEvents()
        {
            return _eventService.GetAllEvents();
        }
        [HttpGet]
        [Route("getEventById/{id}")]
        public EventDTO GetEventById(int id)
        {
            return _eventService.GetEventById(id);
        }
        [HttpGet]
        [Route("getEventByMonth/{month}")]
        public IEnumerable<EventDTO> GetEventByMonth(int month)
        {
            return _eventService.GetEventsByMonth(month);
        }
        
        [HttpPost]
        [Route("addEvent")]
        public void AddEvent([FromBody]EventDTO newEventDTO)
        {
            _eventService.AddEvent(newEventDTO); 
        }

      
    }
}
