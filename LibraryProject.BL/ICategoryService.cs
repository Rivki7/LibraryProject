using Entities.DTO;

namespace LibraryProjectService
{
    public interface ICategoryService
    {
        Task<CategoryDTO> AddCategory(CategoryDTO newCategoryDTO);
        Task<List<CategoryDTO>> GetAllCategories();
    }
}