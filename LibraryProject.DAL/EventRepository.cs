using LibraryProjectRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    public class EventRepository : IEventRepository
    {
        private readonly LibraryContext _libraryContext;
        public EventRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<List<Event>> GetAllEvents()
        {
            try
            {
                List<Event> events = await _libraryContext.Events.ToListAsync();
                   if (events!=null && events.Any())
                {
                    return events;
                }
              throw new Exception("No events found!");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message+ "Error in event Repository");
                return null;
            }
        }

        public async Task<Event> GetEventById(int id)
        {
            try
            {
                Event e = await _libraryContext.Events.FirstOrDefaultAsync(e => e.Id == id);
                if (e != null)
                {
                    return e;
                }
                throw new Exception("No event found with this id");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in event Repository");
                return null;
            }

        }
        public async Task<List<Event>> GetEventsByMonth(int month)
        {
            try
            {
                List<Event> events= await _libraryContext.Events
               .Where(e => e.Date.Month == month)
               .ToListAsync();
                if(events!=null && events.Any())
                {
                    return events;
                }
                throw new Exception("No event found for this month"); 
            }catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in event Repository");
                return null; 
            }
           
        }

        public async Task<Event> AddEvent(Event newEvent)
        {

            using (var transaction =await _libraryContext.Database.BeginTransactionAsync())
            {
                try
                {
                  await _libraryContext.Events.AddAsync(newEvent);
                   await _libraryContext.SaveChangesAsync();

                    var lastAddedEvent =await _libraryContext.Events
                        .OrderByDescending(e => e.Id)
                        .FirstOrDefaultAsync();

                  await  transaction.CommitAsync();

                    return lastAddedEvent;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Failed to add event.", ex);
                    return null;
                }
            }

        }

        public async Task<Event> UpdateEvent(Event updatedEvent)
        {
            try
            {
                var existingEvent = await _libraryContext.Events.FindAsync(updatedEvent.Id);

                if (existingEvent != null)
                {
                    existingEvent.Name = updatedEvent.Name;
                    existingEvent.Date = updatedEvent.Date;
                    existingEvent.Desc = updatedEvent.Desc;
                    _libraryContext.Update(existingEvent);
                    await _libraryContext.SaveChangesAsync();
                    return await _libraryContext.Events.FindAsync(updatedEvent.Id);
                }
                throw new Exception("Event not found"); 
              
            }
            catch (Exception ex) {
                await Console.Out.WriteLineAsync(ex.Message + "Error in event Repository");
                return null; 
            }
          }

        public async Task<bool> DeleteEvent(int id)
        {
            try
            {
                var eventToDelete = await _libraryContext.Events.FindAsync(id);

                if (eventToDelete != null)
                {
                    _libraryContext.Events.Remove(eventToDelete);
                    await _libraryContext.SaveChangesAsync();
                    return true;
                }
               throw new Exception("Event not found");

            }
            catch(Exception ex) 
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in event Repository");
                return false;
            }
            
        }

    }
}
