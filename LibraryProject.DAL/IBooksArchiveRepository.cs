
using LibraryProjectRepository.Models;

namespace LibraryProjectRepository
{
    public interface IBooksArchiveRepository
    {
        Task<BooksArchive> AddBooksArchive(BooksArchive booksArchive);
        Task<List<BooksArchive>> GetAllBooksArchive();
        Task<BooksArchive> GetByIdBooksArchive(int id);
    }
}