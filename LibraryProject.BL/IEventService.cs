using Entities.DTO;
using LibraryProject.DAL.Models;

namespace LibraryProjectService
{
    public interface IEventService
    {
        public List<EventDTO> GetAllEvents();
        public EventDTO GetEventById(int id);
        public IEnumerable<EventDTO> GetEventsByMonth(int month);

        public void AddEvent(EventDTO newEventDTO); 
    }
}