using LibraryProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    internal class TitleRepository
    {

        private readonly LibraryContext _libraryContext= new LibraryContext();

       

        public IEnumerable<Title> GetAllTitles()
        {
            return _libraryContext.Titles.ToList();
        }

        public Title GetTitleById(int id)
        {
            return _libraryContext.Titles.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Title> GetTitlesByCategory(string categoryName)
        {
            return _libraryContext.Titles
                .Where(t => t.CategoryToTitles.Any(ct => ct.Category.Name == categoryName))
                .ToList();
        }

        public IEnumerable<Title> GetTitlesByCategories(IEnumerable<string> categoryNames)
        {
            return _libraryContext.Titles
                .Where(t => t.CategoryToTitles.Any(ct => categoryNames.Contains(ct.Category.Name)))
                .ToList();
        }

        public IEnumerable<Title> GetTitlesByAuthor(string author)
        {
            return _libraryContext.Titles.Where(t => t.Author == author).ToList();
        }
        public IEnumerable<Title> GetTitlesEnteredWithinLast60Days()
        {
            DateTime sixtyDaysAgo = DateTime.Now.AddDays(-60);

            return _libraryContext.Titles
                .Where(t => t.Books.Any(b => b.DateEnter >= sixtyDaysAgo))
                .OrderByDescending(t => t.DateEnter)
                .ToList();
        }
        public void AddTitle(Title title)
        {
            _libraryContext.Titles.Add(title);
            _libraryContext.SaveChanges();
        }

        public void UpdateTitle(int titleId, string newName, string newAuthor, string newDesc)
        {
            var titleToUpdate = _libraryContext.Titles.Find(titleId);

            if (titleToUpdate != null)
            {
                titleToUpdate.Name = newName;
                titleToUpdate.Author = newAuthor;
                titleToUpdate.Desc = newDesc;

                _libraryContext.SaveChanges();
            }
            // Handle the case where the title with the given ID is not found.
        }

        // Add other methods for updating, deleting, or querying Titles
    }

}

