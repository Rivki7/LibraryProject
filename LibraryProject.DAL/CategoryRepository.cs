using LibraryProject.DAL.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LibraryContext _libraryContext;

        public CategoryRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                return await _libraryContext.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching categories", ex);
            }
        }

        public async Task<Category> AddCategory(Category newCategory)
        {
            using var transaction = await _libraryContext.Database.BeginTransactionAsync();
            try
            {
                _libraryContext.Categories.Add(newCategory);
                await _libraryContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return newCategory;
            }
            catch (Exception ex)
            {

                await transaction.RollbackAsync();

                Console.WriteLine("Error occurred while adding category", ex);
                return null;
            }
        }
    }
}
