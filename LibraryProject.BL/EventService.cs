using AutoMapper;
using Entities.DTO;
using LibraryProject.DAL.Models;
using LibraryProjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectService
{
    public class EventService : IEventService
    {
        private IMapper Mapper;
        private IEventRepository _eventRepository;

        public EventService(IMapper mapper, IEventRepository eventRepository)
        {
            Mapper = mapper;
            _eventRepository = eventRepository;
        }
        public List<EventDTO> GetAllEvents()
        {
            List<Event> e = _eventRepository.GetAllEvents(); 
            List<EventDTO> eDTO= Mapper.Map<List<EventDTO>>(_eventRepository.GetAllEvents());
            return eDTO;
        }
        
    }
}
