using AutoMapper;
using Entities.DTO;
using LibraryProjectRepository;
using LibraryProjectRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectService
{
    public class CheckedBookService : ICheckedBookService
    {

        private readonly ICheckedBookRepository _checkedBookRepository;
        private readonly IMapper _mapper;

        public CheckedBookService(ICheckedBookRepository checkedBookRepository, IMapper mapper)
        {
            _checkedBookRepository = checkedBookRepository;
            _mapper = mapper;
        }

        public async Task<CheckedBookDTO> AddCheckedBook(CheckedBookDTO newCheckedBookDTO)
        {
            try
            {
                var newCheckedBook = _mapper.Map<CheckedBook>(newCheckedBookDTO);
                var addedCheckedBook = await _checkedBookRepository.AddCheckedBook(newCheckedBook);
                return _mapper.Map<CheckedBookDTO>(addedCheckedBook);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error occurred while adding checked book: {ex.Message}");
                return null;
            }
        }

        public async Task<List<CheckedBookDTO>> GetCheckedBooksByBookId(int bookId)
        {
            try
            {
                var checkedBooks = await _checkedBookRepository.GetCheckedBooksByBookId(bookId);
                return _mapper.Map<List<CheckedBookDTO>>(checkedBooks);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error occurred while getting checked books by book id: {ex.Message}");
                return null;
            }
        }

        public async Task<List<CheckedBookDTO>> GetCheckedBooksByUserId(int userId)
        {
            try
            {
                var checkedBooks = await _checkedBookRepository.GetCheckedBooksByUserId(userId);
                return _mapper.Map<List<CheckedBookDTO>>(checkedBooks);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error occurred while getting checked books by user id: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateReturnDate(int checkedBookId, DateTime returnDate)
        {
            try
            {
                return await _checkedBookRepository.UpdateReturnDate(checkedBookId, returnDate);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error occurred while updating return date: {ex.Message}");
                return false;
            }
        }
    }
}
