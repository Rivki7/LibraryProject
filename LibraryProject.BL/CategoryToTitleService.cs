using AutoMapper;
using Entities.DTO;
using LibraryProject.DAL.Models;
using LibraryProjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectService
{
    public class CategoryToTitleService : ICategoryToTitleService
    {
        private readonly ICategoryToTitleRepository _categoryToTitleRepository;
        private readonly IMapper _mapper;

        public CategoryToTitleService(ICategoryToTitleRepository categoryToTitleRepository, IMapper mapper)
        {
            _categoryToTitleRepository = categoryToTitleRepository;
            _mapper = mapper;
        }

        public async Task<CategoryToTitleDTO> AddCategoryToTitle(CategoryToTitleDTO newCategoryToTitleDTO)
        {
            try
            {
                var newCategoryToTitle = _mapper.Map<CategoryToTitle>(newCategoryToTitleDTO);
                var addedCategoryToTitle = await _categoryToTitleRepository.AddCategoryToTitle(newCategoryToTitle);
                return _mapper.Map<CategoryToTitleDTO>(addedCategoryToTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddCategoryToTitle function from service layer: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteCategoryToTitle(int titleId)
        {
            try
            {
                return await _categoryToTitleRepository.DeleteCategoryToTitle(titleId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteCategoryToTitle function from service layer: {ex.Message}");
                return false;
            }
        }

        public async Task<List<CategoryToTitleDTO>> GetCategoriesForTitle(int titleId)
        {
            try
            {
                var categories = await _categoryToTitleRepository.GetCategoriesForTitle(titleId);
                return _mapper.Map<List<CategoryToTitleDTO>>(categories);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetCategoriesForTitle function from service layer: {ex.Message}");
                return null;
            }
        }

        public async Task<List<CategoryToTitleDTO>> GetTitlesForCategory(int categoryId)
        {
            try
            {
                var titles = await _categoryToTitleRepository.GetTitlesForCategory(categoryId);
                return _mapper.Map<List<CategoryToTitleDTO>>(titles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTitlesForCategory function from service layer: {ex.Message}");
                return null;
            }
        }

        public async Task<List<CategoryToTitleDTO>> UpdateCategoryForTitleAsync(int titleId, int newCategoryId)
        {
            try
            {
                var updatedCategories = await _categoryToTitleRepository.UpdateCategoryForTitleAsync(titleId, newCategoryId);
                return _mapper.Map<List<CategoryToTitleDTO>>(updatedCategories);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateCategoryForTitleAsync function from service layer: {ex.Message}");
                return null;
            }
        }
    }
}
