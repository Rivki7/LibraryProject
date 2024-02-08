using Entities.DTO;

namespace LibraryProjectService
{
    public interface ILibrarianService
    {
        Task<LibrariansDTO> AddLibrarian(LibrariansDTO newLibrarianDTO);
        Task<bool> DeleteLibrarian(int librarianId);
        Task<List<LibrariansDTO>> GetAllLibrarians();
        Task<LibrariansDTO> GetLibrarianById(int librarianId);
        Task<bool> UpdateLibrarian(LibrariansDTO updatedLibrarianDTO);
    }
}