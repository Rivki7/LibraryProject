using Entities.DTO;
using LibraryProjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitlesController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        [HttpPost]
        public async Task<ActionResult<TitleDTO>> AddTitle([FromBody] TitleDTO titleDTO)
        {
            try
            {
                var addedTitle = await _titleService.AddTitle(titleDTO);
                return CreatedAtAction(nameof(GetTitleById), new { id = addedTitle.Id }, addedTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddTitle API: {ex.Message}");
                return BadRequest("Failed to add title");
            }
        }

        
        [HttpGet]
        public async Task<ActionResult<List<TitleDTO>>> GetAllTitles()
        {
            try
            {
                var titles = await _titleService.GetAllTitles();
                return Ok(titles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllTitles API: {ex.Message}");
                return BadRequest("Failed to retrieve titles");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TitleDTO>> GetTitleById(int id)
        {
            try
            {
                var title = await _titleService.GetTitleById(id);
                if (title == null)
                    return NotFound();

                return Ok(title);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTitleById API: {ex.Message}");
                return BadRequest("Failed to retrieve title");
            }
        }
        
        [HttpGet("author/{author}")]
        public async Task<ActionResult<List<TitleDTO>>> GetTitlesByAuthor(string author)
        {
            try
            {
                var titles = await _titleService.GetTitlesByAuthor(author);
                return Ok(titles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTitlesByAuthor API: {ex.Message}");
                return BadRequest("Failed to retrieve titles by author");
            }
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<TitleDTO>>> GetTitlesByCategories([FromQuery] List<string> categoryNames)
        {
            try
            {
                var titles = await _titleService.GetTitlesByCategories(categoryNames);
                return Ok(titles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTitlesByCategories API: {ex.Message}");
                return BadRequest("Failed to retrieve titles by categories");
            }
        }

        [HttpGet("category/{categoryName}")]
        public async Task<ActionResult<List<TitleDTO>>> GetTitlesByCategory(string categoryName)
        {
            try
            {
                var titles = await _titleService.GetTitlesByCategory(categoryName);
                return Ok(titles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTitlesByCategory API: {ex.Message}");
                return BadRequest("Failed to retrieve titles by category");
            }
        }

        [HttpGet("last60days")]
        public async Task<ActionResult<List<TitleDTO>>> GetTitlesEnteredWithinLast60Days()
        {
            try
            {
                var titles = await _titleService.GetTitlesEnteredWithinLast60Days();
                return Ok(titles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTitlesEnteredWithinLast60Days API: {ex.Message}");
                return BadRequest("Failed to retrieve titles entered within the last 60 days");
            }
        }

        [HttpPut("{titleId}")]
        public async Task<ActionResult<TitleDTO>> UpdateTitle([FromBody] TitleDTO updatedTitle)
        {
            try
            {
                var result = await _titleService.UpdateTitle(updatedTitle);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateTitle API: {ex.Message}");
                return BadRequest("Failed to update title");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTitle(int id)
        {
            try
            {
                var result = await _titleService.DeleteTitle(id);
                if (result)
                    return NoContent();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteTitle API: {ex.Message}");
                return BadRequest("Failed to delete title");
            }
        }


    }
}

