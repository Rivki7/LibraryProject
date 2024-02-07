using LibraryProject.DAL.Models;

namespace LibraryProjectRepository
{
    public interface IOpeningHourRepository
    {
        Task<List<OpeningHour>> GetAllOpeningHours();
        Task<OpeningHour> UpdateOpeningHour(OpeningHour openingHour);
    }
}