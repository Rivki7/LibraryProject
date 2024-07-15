using AutoMapper;
using Entities.DTO;
using LibraryProject.DAL.Models;
using LibraryProjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            try
            {
                var books = await _bookRepository.GetAllBooks();
                return _mapper.Map<List<BookDTO>>(books);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "from GetAllBooksAsync in BookService");
                return null;
            }
        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            try
            {
                var book = await _bookRepository.GetBookById(id);
                return _mapper.Map<BookDTO>(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "from GetBookByIdAsync in BookService");
                return null;
            }
        }

        public async Task<List<BookDTO>> GetBooksByNameAsync(string name)
        {
            try
            {
                var books = await _bookRepository.GetBooksByNameAsync(name);
                return _mapper.Map<List<BookDTO>>(books);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "from GetBooksByNameAsync in BookService");
                return null;
            }
        }

        public async Task<BookDTO> AddBookAsync(BookDTO bookDto)
        {
            try
            {
                var book = _mapper.Map<Book>(bookDto);
                var addedBook = await _bookRepository.AddBookAsync(book);
                return _mapper.Map<BookDTO>(addedBook);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "from AddBookAsync in BookService");
                return null;
            }
        }

        public async Task<BookDTO> UpdateBookAsync(BookDTO updatedBookDto)
        {
            try
            {
                var updatedBook = _mapper.Map<Book>(updatedBookDto);
                var updatedBookEntity = await _bookRepository.UpdateBookAsync(updatedBook);
                return _mapper.Map<BookDTO>(updatedBookEntity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "from UpdateBookAsync in BookService");
                return null;
            }
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            try
            {
                return await _bookRepository.DeleteBookAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "from DeleteBookAsync in BookService");
                return false;
            }
        }
    }
}

