using AutoMapper;
using Entities.DTO;
using LibraryProjectRepository;
using LibraryProjectRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> AddCategory(CategoryDTO newCategoryDTO)
        {
            try
            {
                var newCategory = _mapper.Map<Category>(newCategoryDTO);
                var addedCategory = await _categoryRepository.AddCategory(newCategory);
                return _mapper.Map<CategoryDTO>(addedCategory);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while adding category", ex);
                return null;
            }
        }

        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategories();
                return _mapper.Map<List<CategoryDTO>>(categories);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while fetching categories", ex);
                return null;
            }
        }
    }
}
