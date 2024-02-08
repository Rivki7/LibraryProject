using LibraryProject.DAL.Models;

namespace LibraryProjectRepository
{
    public interface ILibrarianRepository
    {
        Task<Librarian> AddLibrarian(Librarian newLibrarian);
        Task<bool> DeleteLibrarian(int librarianId);
        Task<List<Librarian>> GetAllLibrarians();
        Task<Librarian> GetLibrarianById(int librarianId);
        Task<bool> UpdateLibrarian(Librarian updatedLibrarian);
    }
}