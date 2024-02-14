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
    public class LibrarianService : ILibrarianService
    {
        private readonly ILibrarianRepository _librarianRepository;
        private readonly IMapper _mapper;

        public LibrarianService(ILibrarianRepository librarianRepository, IMapper mapper)
        {
            _librarianRepository = librarianRepository;
            _mapper = mapper;
        }

        public async Task<LibrariansDTO> AddLibrarian(LibrariansDTO newLibrarianDTO)
        {
            try
            {
                var newLibrarian = _mapper.Map<Librarian>(newLibrarianDTO);
                var addedLibrarian = await _librarianRepository.AddLibrarian(newLibrarian);
                return _mapper.Map<LibrariansDTO>(addedLibrarian);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error occurred while adding librarian: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteLibrarian(int librarianId)
        {
            try
            {
                return await _librarianRepository.DeleteLibrarian(librarianId);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error occurred while deleting librarian: {ex.Message}");
                return false;
            }
        }

        public async Task<List<LibrariansDTO>> GetAllLibrarians()
        {
            try
            {
                var librarians = await _librarianRepository.GetAllLibrarians();
                return _mapper.Map<List<LibrariansDTO>>(librarians);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting all librarians: {ex.Message}");
                return null;
            }
        }

        public async Task<LibrariansDTO> GetLibrarianById(int librarianId)
        {
            try
            {
                var librarian = await _librarianRepository.GetLibrarianById(librarianId);
                return _mapper.Map<LibrariansDTO>(librarian);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error occurred while getting librarian by ID: {ex.Message}");
                return null;
            }
        }

        public async Task<LibrariansDTO> UpdateLibrarian(LibrariansDTO updatedLibrarianDto)
        {
            try
            {
                Librarian updatedLibrarian = _mapper.Map<Librarian>(updatedLibrarianDto);

                Librarian updatedEntity = await _librarianRepository.UpdateLibrarian(updatedLibrarian);

                return _mapper.Map<LibrariansDTO>(updatedEntity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating librarian by ID from UpdateLibrarian in service layer: {ex.Message}");
                return null;
            }
        }



    }
}
