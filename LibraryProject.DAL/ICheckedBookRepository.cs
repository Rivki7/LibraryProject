using LibraryProject.DAL.Models;

namespace LibraryProjectRepository
{
    public interface ICheckedBookRepository
    {
        Task<CheckedBook> AddCheckedBook(CheckedBook newCheckedBook);
        Task<List<CheckedBook>> GetCheckedBooksByBookId(int bookId);
        Task<List<CheckedBook>> GetCheckedBooksByUserId(int userId);
        Task<bool> UpdateReturnDate(int checkedBookId, DateTime returnDate);
    }
}