using LibraryProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    public class EventRepository : IEventRepository
    {
        private readonly LibraryContext _libraryContext = new LibraryContext();

        public List<Event> GetAllEvents()
        {
            return _libraryContext.Events.ToList();
        }

        public Event GetEventById(int id)
        {
            return _libraryContext.Events.FirstOrDefault(e => e.Id == id);
        }
        public IEnumerable<Event> GetEventsByMonth(int month)
        {
            return _libraryContext.Events
                .Where(e => e.Date.Month == month)
                .ToList();
        }

        public void AddEvent(Event newEvent)
        {
            _libraryContext.Events.Add(newEvent);
            _libraryContext.SaveChanges();
        }

        public void UpdateEvent(Event updatedEvent)
        {
            var existingEvent = _libraryContext.Events.Find(updatedEvent.Id);

            if (existingEvent != null)
            {
                existingEvent.Name = updatedEvent.Name;
                existingEvent.Date = updatedEvent.Date;
                existingEvent.Desc = updatedEvent.Desc;

                _libraryContext.SaveChanges();
            }
            // Handle the case where the event with the given ID is not found.
        }

        public void DeleteEvent(int id)
        {
            var eventToDelete = _libraryContext.Events.Find(id);

            if (eventToDelete != null)
            {
                _libraryContext.Events.Remove(eventToDelete);
                _libraryContext.SaveChanges();
            }
            // Handle the case where the event with the given ID is not found.
        }

        // Add other methods for updating, deleting, or querying Events
    }
}
