using LibraryProject.DAL.Models;

namespace LibraryProjectRepository
{
    public interface IEventRepository
    {
        List<Event> GetAllEvents();
        Event GetEventById(int id);
        IEnumerable<Event> GetEventsByMonth(int month);
        void AddEvent(Event newEvent);
        public void UpdateEvent(Event updatedEvent);
        void DeleteEvent(int id);
    }
}