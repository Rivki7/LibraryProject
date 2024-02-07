using LibraryProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    public class BooksArchiveRepository : IBooksArchiveRepository
    {
        private readonly LibraryContext _libraryContext;

        public BooksArchiveRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public async Task<BooksArchive> AddBooksArchive(BooksArchive booksArchive)
        {
            using (var transaction = await _libraryContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _libraryContext.BooksArchives.AddAsync(booksArchive);
                    await _libraryContext.SaveChangesAsync();


                    var newlyAddedBooksArchive = await _libraryContext.BooksArchives
                        .OrderByDescending(ba => ba.Id)
                        .FirstOrDefaultAsync();

                    await transaction.CommitAsync();

                    return newlyAddedBooksArchive;
                }
                catch (Exception ex)
                {

                    await transaction.RollbackAsync();

                    Console.WriteLine(("Failed to add BooksArchive.", ex));
                    return null;
                }
            }
        }

        public async Task<List<BooksArchive>> GetAllBooksArchive()
        {
            try
            {
                List<BooksArchive> archivedBooks = await _libraryContext.BooksArchives.ToListAsync();

                if (archivedBooks != null)
                {
                    return archivedBooks;
                }
                return null;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Failed to retrieve BooksArchives.", ex);
                return null;
            }
        }

        public async Task<BooksArchive> GetByIdBooksArchive(int id)
        {
            try
            {
                return await _libraryContext.BooksArchives.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to retrieve BooksArchive with id {id}.", ex);
            }
        }
    }
}
