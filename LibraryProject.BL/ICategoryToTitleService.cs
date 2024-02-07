using Entities.DTO;

namespace LibraryProjectService
{
    public interface ICategoryToTitleService
    {
        Task<CategoryToTitleDTO> AddCategoryToTitle(CategoryToTitleDTO newCategoryToTitleDTO);
        Task<bool> DeleteCategoryToTitle(int titleId);
        Task<List<CategoryToTitleDTO>> GetCategoriesForTitle(int titleId);
        Task<List<CategoryToTitleDTO>> GetTitlesForCategory(int categoryId);
        Task<List<CategoryToTitleDTO>> UpdateCategoryForTitleAsync(int titleId, int newCategoryId);
    }
}