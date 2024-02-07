using Entities.DTO;

namespace LibraryProjectService
{
    public interface IBooksArchiveService
    {
        Task<BooksArchiveDTO> AddBooksArchive(BooksArchiveDTO booksArchiveDTO);
        Task<List<BooksArchiveDTO>> GetAllBooksArchive();
        Task<BooksArchiveDTO> GetBooksArchiveById(int id);
    }
}