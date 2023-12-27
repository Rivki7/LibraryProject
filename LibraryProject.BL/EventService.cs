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
                List<EventDTO> eventsDTO = _mapper.Map<List<EventDTO>>(events);
                return eventsDTO;
            }catch (Exception ex)
            {
                return null; 
            }
           
        }

        public async Task<EventDTO> GetEventById(int id)
        {
            Event eventEntity = await _eventRepository.GetEventById(id);

            EventDTO eventDto = _mapper.Map<EventDTO>(eventEntity);

            return eventDto;
        }

        public async Task<List<EventDTO>> GetEventsByMonth(int month)
        {
            List<Event> eventEntities = await _eventRepository.GetEventsByMonth(month);

            List<EventDTO> eventDtos = _mapper.Map<List<EventDTO>>(eventEntities);

            return eventDtos;
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

                return isDeleted;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
