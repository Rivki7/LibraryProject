using AutoMapper;
using Entities.DTO;
using LibraryProject.DAL.Models;
using LibraryProjectRepository;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectService
{
    public class EventService : IEventService
    {
        private IMapper _mapper;
        private IEventRepository _eventRepository;

        public EventService(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }
        public async Task<List<EventDTO>> GetAllEvents()
        {
            try
            {
                List<Event> events = await _eventRepository.GetAllEvents();
                if(events != null && events.Any())
                {
                    List<EventDTO> eventsDTO = _mapper.Map<List<EventDTO>>(events);
                    return eventsDTO;
                }
                throw new Exception("No events found!"); 
                
            }catch (Exception ex)
            {
                await Console.Out.WriteLineAsync( ex.Message +" Error in event service");
                return null; 
            }
           
        }

        public async Task<EventDTO> GetEventById(int id)
        {
            try
            {
                Event eventEntity = await _eventRepository.GetEventById(id);

                if (eventEntity != null)
                {
                    EventDTO eventDto = _mapper.Map<EventDTO>(eventEntity);
                    return eventDto;
                }
                throw new Exception("No event found with this id");
                
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + " Error in event service");
                return null;
            }
        }


        public async Task<List<EventDTO>> GetEventsByMonth(int month)
        {
            try
            {
                List<Event> eventEntities = await _eventRepository.GetEventsByMonth(month);

                if (eventEntities != null && eventEntities.Any())
                {
                    List<EventDTO> eventDtos = _mapper.Map<List<EventDTO>>(eventEntities);
                    return eventDtos;
                }
                throw new Exception("No events found fot this month");
               
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + " Error in event service");
                return null;
            }
        }


        public async Task<EventDTO> AddEvent(EventDTO newEventDTO)
        {
            try
            {
                Event newEvent = _mapper.Map<Event>(newEventDTO);
                Event addedEvent = await _eventRepository.AddEvent(newEvent);
                return _mapper.Map<EventDTO>(addedEvent);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

     
        public async Task<EventDTO> UpdateEvent(EventDTO updatedEventDto)
        {
            try
            {
                Event updatedEvent = _mapper.Map<Event>(updatedEventDto);

                Event existingEvent = await _eventRepository.UpdateEvent(updatedEvent);

                EventDTO resultEventDto = _mapper.Map<EventDTO>(existingEvent);

                return resultEventDto;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public async Task<bool> DeleteEvent(int id)
        {
            try
            {
                bool isDeleted = await _eventRepository.DeleteEvent(id);
                if (isDeleted)
                {
                    return isDeleted;
                }
                throw new Exception("Event not found"); 
                
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in event Service");
                return false;
            }
        }

    }
}
