using LibraryProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    public class LibrarianRepository : ILibrarianRepository
    {

        private readonly LibraryContext _libraryContext;

        public LibrarianRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<Librarian> AddLibrarian(Librarian newLibrarian)
        {
            try
            {
                _libraryContext.Librarians.Add(newLibrarian);
                await _libraryContext.SaveChangesAsync();
                return newLibrarian;
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Error in LibrarianRepository AddLibrarianAsync function: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Librarian>> GetAllLibrarians()
        {
            try
            {
                return await _libraryContext.Librarians.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Error in LibrarianRepository GetAllLibrariansAsync function: {ex.Message}");
                return null;
            }
        }

        public async Task<Librarian> GetLibrarianById(int librarianId)
        {
            try
            {
                return await _libraryContext.Librarians.FindAsync(librarianId);
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Error in LibrarianRepository GetLibrarianByIdAsync function: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateLibrarian(Librarian updatedLibrarian)
        {
            try
            {
                _libraryContext.Entry(updatedLibrarian).State = EntityState.Modified;
                await _libraryContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error in LibrarianRepository UpdateLibrarianAsync function: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteLibrarian(int librarianId)
        {
            var librarian = await _libraryContext.Librarians.FindAsync(librarianId);
            if (librarian == null)
                return false;

            try
            {
                _libraryContext.Librarians.Remove(librarian);
                await _libraryContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error in LibrarianRepository DeleteLibrarianAsync function: {ex.Message}");
                return false;
            }
        }
    }
}
