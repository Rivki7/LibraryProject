using LibraryProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    public class TitleRepository : ITitleRepository
    {

        private readonly LibraryContext _libraryContext;
        public TitleRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<List<Title>> GetAllTitles()
        {
            try
            {
                List<Title> titles = await _libraryContext.Titles.ToListAsync();
                if (titles != null && titles.Any())
                {
                    return titles;
                }
                throw new Exception("No titles found");
            }
            catch (Exception ex)
            {

                await Console.Out.WriteLineAsync(ex.Message + "Error in Title Repository. Func name: GetAllTitles");
                return null;
            }
        }

        public async Task<Title> GetTitleById(int id)
        {
            try
            {
                Title title = await _libraryContext.Titles.FindAsync(id);
                if (title != null)
                {
                    return title;
                }
                throw new Exception($"No title found with the id of {id}");

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in Title Repository. Func name: GetTitleById");
                return null;
            }
        }

        public async Task<List<Title>> GetTitlesByCategory(string categoryName)
        {
            try
            {
                List<Title> titles = await _libraryContext.Titles
                .Where(t => t.CategoryToTitles.Any(ct => ct.Category.Name == categoryName))
                .ToListAsync();
                if (titles != null && titles.Any())
                {
                    return titles;
                }
                throw new Exception($"No titles found for the category {categoryName}");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in Title Repository. Func name: GetTitlesByCategory");
                return null;
            }

        }

        public async Task<List<Title>> GetTitlesByCategories(List<string> categoryNames)
        {
            try
            {
                List<Title> titles = await _libraryContext.Titles
                    .Where(t => t.CategoryToTitles.Any(ct => categoryNames.Contains(ct.Category.Name)))
                    .ToListAsync();
                if (titles != null && titles.Any()) { return titles; }
                throw new Exception("No titles found for these categories");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in Title Repository. Func name: GetTitlesByCategories");
                return null;
            }

        }

        public async Task<List<Title>> GetTitlesByAuthor(string author)
        {
            try
            {
                List<Title> titles = await _libraryContext.Titles.Where(t => t.Author == author).ToListAsync();
                if (titles != null && titles.Any())
                {
                    return titles;
                }
                throw new Exception("No titles found for this author");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in Title Repository. Func name: GetTitlesByAuthor");
                return null;
            }


        }
        public async Task<List<Title>> GetTitlesEnteredWithinLast60Days()
        {
            try
            {
                DateTime sixtyDaysAgo = DateTime.Now.AddDays(-60);
                List<Title> titles = await _libraryContext.Titles
                    .Where(t => t.Books.Any(b => b.DateEnter >= sixtyDaysAgo))
                    .OrderByDescending(t => t.DateEnter)
                    .ToListAsync();
                if (titles != null && titles.Any())
                {
                    return titles;
                }
                throw new Exception("No titles found");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in Title Repository. Func name: GetTitlesEnteredWithinLast60Days");
                return null;
            }

        }
        public async Task<Title> AddTitle(Title title)
        {

            using (var transaction = await _libraryContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _libraryContext.Titles.AddAsync(title);
                    await _libraryContext.SaveChangesAsync();

                    var lastAddedTitle = await _libraryContext.Titles
                        .OrderByDescending(e => e.Id)
                        .FirstOrDefaultAsync();

                    await transaction.CommitAsync();

                    return lastAddedTitle;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Failed to add event.", ex);
                    return null;
                }
            }
        }

        // Inside the class implementing ITitleRepository
        public async Task<Title> UpdateTitle(Title updatedTitle)
        {
            try
            {
                var titleToUpdate = await _libraryContext.Titles.FindAsync(updatedTitle.Id);

                if (titleToUpdate != null)
                {
                    // Update properties based on the provided Title object
                    titleToUpdate.Name = updatedTitle.Name;
                    titleToUpdate.Author = updatedTitle.Author;
                    titleToUpdate.Desc = updatedTitle.Desc;

                    await _libraryContext.SaveChangesAsync();

                    // Return the updated title
                    return titleToUpdate;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating title: {ex.Message}");
                return null;
            }
        }


        public async Task<bool> DeleteTitle(int id)
        {
            try
            {
                var titleToDelete = await _libraryContext.Titles.FindAsync(id);

                if (titleToDelete != null)
                {
                    _libraryContext.Titles.Remove(titleToDelete);
                    await _libraryContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in Delete Title Repository");
                return false;
            }

        }

    }

}

