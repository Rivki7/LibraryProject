using Entities.DTO;
using LibraryProjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryToTitleController : ControllerBase
    {
        private readonly ICategoryToTitleService _categoryToTitleService;

        public CategoryToTitleController(ICategoryToTitleService categoryToTitleService)
        {
            _categoryToTitleService = categoryToTitleService;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryToTitleDTO>> AddCategoryToTitle(CategoryToTitleDTO newCategoryToTitleDTO)
        {
            try
            {
                var addedCategoryToTitle = await _categoryToTitleService.AddCategoryToTitle(newCategoryToTitleDTO);
                if (addedCategoryToTitle == null)
                {
                    return BadRequest();
                }
                return CreatedAtAction(nameof(AddCategoryToTitle), addedCategoryToTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while adding category to title: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{titleId}")]
        public async Task<ActionResult> DeleteCategoryToTitle(int titleId)
        {
            try
            {
                var result = await _categoryToTitleService.DeleteCategoryToTitle(titleId);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting category to title: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("title/{titleId}")]
        public async Task<ActionResult<List<CategoryToTitleDTO>>> GetCategoriesForTitle(int titleId)
        {
            try
            {
                var categories = await _categoryToTitleService.GetCategoriesForTitle(titleId);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting categories for title: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<List<CategoryToTitleDTO>>> GetTitlesForCategory(int categoryId)
        {
            try
            {
                var titles = await _categoryToTitleService.GetTitlesForCategory(categoryId);
                if (titles == null)
                {
                    return NotFound();
                }
                return Ok(titles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting titles for category: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{titleId}")]
        public async Task<ActionResult<List<CategoryToTitleDTO>>> UpdateCategoryForTitleAsync(int titleId, [FromBody] int newCategoryId)
        {
            try
            {
                var updatedCategories = await _categoryToTitleService.UpdateCategoryForTitleAsync(titleId, newCategoryId);
                if (updatedCategories == null)
                {
                    return BadRequest();
                }
                return Ok(updatedCategories);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating category for title: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
