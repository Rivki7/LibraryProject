using Entities.DTO;

namespace LibraryProjectService
{
    public interface ICheckedBookService
    {
        Task<CheckedBookDTO> AddCheckedBook(CheckedBookDTO newCheckedBookDTO);
        Task<List<CheckedBookDTO>> GetCheckedBooksByBookId(int bookId);
        Task<List<CheckedBookDTO>> GetCheckedBooksByUserId(int userId);
        Task<bool> UpdateReturnDate(int checkedBookId, DateTime returnDate);
    }
}