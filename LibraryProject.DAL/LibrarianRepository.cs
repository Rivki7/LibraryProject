using LibraryProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    public class LibrarianRepository :ILibrarianRepository
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

        public async Task<Librarian> UpdateLibrarian(Librarian updatedLibrarian)
        {
            using (var transaction = _libraryContext.Database.BeginTransaction())
            {
                try
                {
                    var existingLibrarian = await _libraryContext.Librarians.FindAsync(updatedLibrarian.Id);
                    if (existingLibrarian == null)
                    {
                        throw new ArgumentException($"Librarian with ID {updatedLibrarian.Id} not found.");
                    }

                    _libraryContext.Entry(existingLibrarian).State = EntityState.Modified;

                    existingLibrarian.FirstName = updatedLibrarian.FirstName;
                    existingLibrarian.LastName = updatedLibrarian.LastName;
                    existingLibrarian.PhoneNumber1 = updatedLibrarian.PhoneNumber1;
                    existingLibrarian.PhoneNumber2 = updatedLibrarian.PhoneNumber2;
                    existingLibrarian.Email = updatedLibrarian.Email;
                    existingLibrarian.BirthDate = updatedLibrarian.BirthDate;
                    existingLibrarian.Address = updatedLibrarian.Address;
                    existingLibrarian.City = updatedLibrarian.City;
                    existingLibrarian.IsBlocked = updatedLibrarian.IsBlocked;


                    await _libraryContext.SaveChangesAsync();

                    transaction.Commit();

                    return existingLibrarian;
                }
                catch (Exception ex)
                {
                    // Rollback transaction on error
                    transaction.Rollback();
                    throw; // Re-throw the exception for further handling
                }
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
