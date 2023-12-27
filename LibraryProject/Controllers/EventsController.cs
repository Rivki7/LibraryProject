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
        public async Task<ActionResult<List<EventDTO>>> GetAllEvents()
        {
            try
            {
                List<EventDTO> events = await _eventService.GetAllEvents();

                if (events != null && events.Any())
                {
                    return Ok(events);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("getEventById/{id}")]
        public async Task<ActionResult<EventDTO>> GetEventById(int id)
        {
            try
            {
                EventDTO eventDto = await _eventService.GetEventById(id);

                if (eventDto != null)
                {
                    return Ok(eventDto);
                }
                else
                {
                     return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("getEventByMonth/{month}")]
        public async Task<ActionResult<List<EventDTO>>> GetEventByMonth(int month)
        {
            try
            {
                List<EventDTO> events = await _eventService.GetEventsByMonth(month);

                if (events != null && events.Any())
                {
                    return Ok(events);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost]
        [Route("addEvent")]
        public async Task<ActionResult<EventDTO>> AddEvent([FromBody] EventDTO newEventDTO)
        {
            try
            {  
                EventDTO addedEventDTO = await _eventService.AddEvent(newEventDTO);

                if (addedEventDTO != null)
                {
                   return CreatedAtAction(nameof(AddEvent), new { id = addedEventDTO.Id }, addedEventDTO);
                }
                else
                {
                    return BadRequest("Failed to add the event");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPut]
        [Route("updateEvent")]
        public async Task<ActionResult<EventDTO>> UpdateEvent([FromBody] EventDTO updatedEventDto)
        {
            try
            {
               EventDTO resultEventDto = await _eventService.UpdateEvent(updatedEventDto);

                if (resultEventDto != null)
                {
                     return Ok(resultEventDto);
                }
                else
                {
                     return NotFound("Event not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("deleteEvent/{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            try
            {
                bool isDeleted = await _eventService.DeleteEvent(id);

                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                   return NotFound("Event not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


    }
}
