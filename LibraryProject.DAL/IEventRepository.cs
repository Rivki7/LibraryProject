using LibraryProject.DAL.Models;

namespace LibraryProjectRepository
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEvents();
        Task<Event> GetEventById(int id);
        Task<List<Event>> GetEventsByMonth(int month);
        Task<Event> AddEvent(Event newEvent);
        Task<Event> UpdateEvent(Event updatedEvent);
        Task<bool> DeleteEvent(int id);
    }
}