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
      
       private readonly LibraryContext _libraryContext= new LibraryContext();

        public IEnumerable<Book> GetAllBooks()
        {
            return _libraryContext.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _libraryContext.Books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetBooksByName(string name)
        {
            return _libraryContext.Books.Where(b => b.Title.Name == name).ToList();
        }

        public void AddBook(Book book)
        {
            _libraryContext.Books.Add(book);
            _libraryContext.SaveChanges();
        }

       
    }

}

