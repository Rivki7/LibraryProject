using LibraryProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    public class CheckedBookRepository : ICheckedBookRepository
    {

        private readonly LibraryContext _libraryContext;

        public CheckedBookRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<CheckedBook> AddCheckedBook(CheckedBook newCheckedBook)
        {
            using var transaction = await _libraryContext.Database.BeginTransactionAsync();
            try
            {
                _libraryContext.CheckedBooks.Add(newCheckedBook);
                await _libraryContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return newCheckedBook;
            }
            catch (Exception ex)
            {

                await transaction.RollbackAsync();

                Console.WriteLine($"Error in CheckedBookRepository AddCheckedBookAsync function: {ex.Message}");
                return null;
            }
        }

        public async Task<List<CheckedBook>> GetCheckedBooksByUserId(int userId)
        {
            try
            {
                return await _libraryContext.CheckedBooks
                    .Where(cb => cb.UserId == userId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error in CheckedBookRepository GetCheckedBooksByUserIdAsync function: {ex.Message}");
                return null;
            }
        }

        public async Task<List<CheckedBook>> GetCheckedBooksByBookId(int bookId)
        {
            try
            {
                return await _libraryContext.CheckedBooks
                    .Where(cb => cb.BookId == bookId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error in CheckedBookRepository GetCheckedBooksByBookIdAsync function: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateReturnDate(int checkedBookId, DateTime returnDate)
        {
            var checkedBook = await _libraryContext.CheckedBooks.FindAsync(checkedBookId);
            if (checkedBook == null)
                return false;

            checkedBook.ReturnDate = returnDate;

            try
            {
                await _libraryContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error in CheckedBookRepository UpdateReturnDateAsync function: {ex.Message}");
                return false;
            }
        }
    }
}
