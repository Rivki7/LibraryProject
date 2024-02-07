using LibraryProject.DAL.Models;

namespace LibraryProjectRepository
{
    public interface ICategoryToTitleRepository
    {
        Task<CategoryToTitle> AddCategoryToTitle(CategoryToTitle newCategoryToTitle);
        Task<bool> DeleteCategoryToTitle(int titleId);
        Task<List<CategoryToTitle>> GetCategoriesForTitle(int titleId);
        Task<List<CategoryToTitle>> GetTitlesForCategory(int categoryId);
        Task<List<CategoryToTitle>> UpdateCategoryForTitleAsync(int titleId, int newCategoryId);
    }
}