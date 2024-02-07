using LibraryProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    public class CategoryToTitleRepository : ICategoryToTitleRepository
    {
        private readonly LibraryContext _libraryContext;

        public CategoryToTitleRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<CategoryToTitle> AddCategoryToTitle(CategoryToTitle newCategoryToTitle)
        {
            using var transaction = await _libraryContext.Database.BeginTransactionAsync();
            try
            {
                _libraryContext.CategoryToTitles.Add(newCategoryToTitle);
                await _libraryContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return newCategoryToTitle;
            }
            catch (Exception ex)
            {

                await transaction.RollbackAsync();

                throw new Exception("Error occurred while adding category to title", ex);
            }
        }

        public async Task<List<CategoryToTitle>> GetCategoriesForTitle(int titleId)
        {
            return await _libraryContext.CategoryToTitles
                .Where(ctt => ctt.TitleId == titleId)
                .ToListAsync();
        }

        public async Task<List<CategoryToTitle>> GetTitlesForCategory(int categoryId)
        {
            return await _libraryContext.CategoryToTitles
                .Where(ctt => ctt.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<List<CategoryToTitle>> UpdateCategoryForTitleAsync(int titleId, int newCategoryId)
        {
            var categoryToTitle = await _libraryContext.CategoryToTitles
                .FirstOrDefaultAsync(ctt => ctt.TitleId == titleId);

            if (categoryToTitle != null)
            {
                categoryToTitle.CategoryId = newCategoryId;
                await _libraryContext.SaveChangesAsync();


                var updatedCategories = await _libraryContext.CategoryToTitles
                    .Where(ctt => ctt.TitleId == titleId)
                    .ToListAsync();

                return updatedCategories;
            }
            else
            {
                Console.WriteLine("Problem in CategoryToTitleRepository layer - UpdateCategoryForTitleAsync");
                return null;
            }
        }

        public async Task<bool> DeleteCategoryToTitle(int titleId)
        {
            var categoryToTitle = await _libraryContext.CategoryToTitles
                .FirstOrDefaultAsync(ctt => ctt.TitleId == titleId);

            if (categoryToTitle != null)
            {
                _libraryContext.CategoryToTitles.Remove(categoryToTitle);
                await _libraryContext.SaveChangesAsync();
                return true;
            }
            else
            {
                Console.WriteLine("Problem in CategoryToTitleRepository - DeleteCategoryToTitle");
                return false;
            }
        }


    }
}
