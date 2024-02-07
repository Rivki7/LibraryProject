using LibraryProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    public class BookRepository
    {

        private readonly LibraryContext _libraryContext;

        public BookRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            try
            {
                List < Book > books = await _libraryContext.Books.ToListAsync();
                if(books!=null && books.Any() )
                {
                    return books;
                }
                throw new Exception("No books found!"); 
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in OpenHour Repository");
                return null; 
            }
        }


        public async Task<Book> GetBookById(int id)
        {
            try
            {
                Book book= await _libraryContext.Books.FirstOrDefaultAsync(b => b.Id == id);
                if (book != null)
                {
                    return book;
                }
                throw new Exception("Book not found"); 
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in event Repository - GetBookById");
                return null; // Return null or handle the exception accordingly
            }
        }


        public async Task<List<Book>> GetBooksByNameAsync(string name)
        {
            try
            {
                var books = await _libraryContext.Books
                    .Where(b => b.Title.Name == name)
                    .ToListAsync();
                if(books!=null && books.Any())
                {
                    return books;
                }
               throw new   Exception("No book with this name was found");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in Book Repository");

                return null ;
            }
        }


        public async Task<Book> AddBookAsync(Book book)
        {
            using (var transaction = await _libraryContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _libraryContext.Books.AddAsync(book);

                    await _libraryContext.SaveChangesAsync();

                     _libraryContext.Entry(book).State = EntityState.Detached;

                    var newlyAddedBook = await _libraryContext.Books
                        .SingleOrDefaultAsync(b => b.Id == book.Id);

                    await transaction.CommitAsync();

                    return newlyAddedBook;
                }
                catch (Exception ex)
                {
                   
                    await transaction.RollbackAsync();

                    return null; 
                }
            }
        }

        public async Task<Book> UpdateBookAsync(Book updatedBook)
        {
            try
            {
                var existingBook = await _libraryContext.Books.FindAsync(updatedBook.Id);

                if (existingBook != null)
                {
                    existingBook.TitleId = updatedBook.TitleId;
                    existingBook.DateEnter = updatedBook.DateEnter;

                    _libraryContext.Update(existingBook);
                    await _libraryContext.SaveChangesAsync();

                    return await _libraryContext.Books.FindAsync(updatedBook.Id);
                }
                throw new Exception("Book not found!");
                
                
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in Book Repository");

                return null; 
            }
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            try
            {
                var bookToDelete = await _libraryContext.Books.FindAsync(id);

                if (bookToDelete != null)
                {
                    _libraryContext.Books.Remove(bookToDelete);
                    await _libraryContext.SaveChangesAsync();

                    return true;
                }

                throw new Exception("Book not found"); 
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in Book Repository");

                return false; // Return false or handle the exception accordingly
            }
        }



    }

}

