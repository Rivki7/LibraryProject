using LibraryProject.DAL.Models;

namespace LibraryProjectRepository
{
    public interface IEventRepository
    {
        void AddEvent(Event newEvent);
        void DeleteEvent(int id);
        List<Event> GetAllEvents();
        Event GetEventById(int id);
        IEnumerable<Event> GetEventsByMonth(int month);
        void UpdateEvent(Event updatedEvent);
    }
}