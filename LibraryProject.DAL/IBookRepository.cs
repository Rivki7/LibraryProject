
using LibraryProjectRepository.Models;

namespace LibraryProjectRepository
{
    public interface IBookRepository
    {
        Task<Book> AddBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<List<Book>> GetBooksByNameAsync(string name);
        Task<Book> UpdateBookAsync(Book updatedBook);
    }
}