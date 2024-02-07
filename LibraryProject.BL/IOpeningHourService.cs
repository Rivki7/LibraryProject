using Entities.DTO;

namespace LibraryProjectService
{
    public interface IOpeningHourService
    {
        Task<List<OpeningHourDTO>> GetAllOpeningHours();
        Task<OpeningHourDTO> UpdateOpeningHour(OpeningHourDTO updatedOpeningHourDTO);
    }
}