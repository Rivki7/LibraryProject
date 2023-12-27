using Entities.DTO;
using LibraryProject.DAL.Models;

namespace LibraryProjectService
{
    public interface IEventService
    {
         Task<List<EventDTO>> GetAllEvents();
         Task<EventDTO> GetEventById(int id);
         Task<List<EventDTO>> GetEventsByMonth(int month);

        Task<EventDTO> AddEvent(EventDTO newEventDTO);

        Task<EventDTO> UpdateEvent(EventDTO updatedEvent);
        Task<bool> DeleteEvent(int id);
    }
}