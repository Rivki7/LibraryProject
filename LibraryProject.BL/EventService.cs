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
        public List<EventDTO> GetAllEvents()
        {
            List<Event> events = _eventRepository.GetAllEvents(); 
            List<EventDTO> eventsDTO= _mapper.Map<List<EventDTO>>(_eventRepository.GetAllEvents());
            return eventsDTO;
        }

        public EventDTO GetEventById(int id)
        {
            // Retrieve the event from the DAL layer
            Event eventEntity = _eventRepository.GetEventById(id);

            // Map the entity to DTO using the IMapper
            EventDTO eventDto = _mapper.Map<EventDTO>(eventEntity);

            return eventDto;
        }

        public IEnumerable<EventDTO> GetEventsByMonth(int month)
        {
            // Retrieve the events from the DAL layer
            IEnumerable<Event> eventEntities = _eventRepository.GetEventsByMonth(month);

            // Map the entities to DTOs using the IMapper
            IEnumerable<EventDTO> eventDtos = _mapper.Map<IEnumerable<EventDTO>>(eventEntities);

            return eventDtos;
        }


        public void AddEvent(EventDTO newEventDTO)
        {
            // Map the Event to the entity using the IMapper
            Event newEvent = _mapper.Map<Event>(newEventDTO);

            // Add the event to the DAL layer
            _eventRepository.AddEvent(newEvent);
        }


    }
}
