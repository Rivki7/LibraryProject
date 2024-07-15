using Entities.DTO;

namespace LibraryProjectService
{
    public interface IBookService
    {
        Task<BookDTO> AddBookAsync(BookDTO bookDto);
        Task<bool> DeleteBookAsync(int id);
        Task<List<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<List<BookDTO>> GetBooksByNameAsync(string name);
        Task<BookDTO> UpdateBookAsync(BookDTO updatedBookDto);
    }
}