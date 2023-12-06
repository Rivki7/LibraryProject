using Entities.DTO;
using LibraryProject.DAL.Models;

namespace LibraryProjectService
{
    public interface IEventService
    {
        public List<EventDTO> GetAllEvents();
    }
}