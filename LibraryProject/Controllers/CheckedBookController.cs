using Entities.DTO;
using LibraryProjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckedBookController : ControllerBase
    {
        private readonly ICheckedBookService _checkedBookService;

        public CheckedBookController(ICheckedBookService checkedBookService)
        {
            _checkedBookService = checkedBookService;
        }

        [HttpPost]
        public async Task<ActionResult<CheckedBookDTO>> AddCheckedBook(CheckedBookDTO newCheckedBookDTO)
        {
            try
            {
                var addedCheckedBook = await _checkedBookService.AddCheckedBook(newCheckedBookDTO);
                if (addedCheckedBook == null)
                {
                    return BadRequest();
                }
                return CreatedAtAction(nameof(AddCheckedBook), addedCheckedBook);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while adding checked book: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("book/{bookId}")]
        public async Task<ActionResult<List<CheckedBookDTO>>> GetCheckedBooksByBookId(int bookId)
        {
            try
            {
                var checkedBooks = await _checkedBookService.GetCheckedBooksByBookId(bookId);
                if (checkedBooks == null)
                {
                    return NotFound();
                }
                return Ok(checkedBooks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting checked books by book id: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<CheckedBookDTO>>> GetCheckedBooksByUserId(int userId)
        {
            try
            {
                var checkedBooks = await _checkedBookService.GetCheckedBooksByUserId(userId);
                if (checkedBooks == null)
                {
                    return NotFound();
                }
                return Ok(checkedBooks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting checked books by user id: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{checkedBookId}")]
        public async Task<ActionResult> UpdateReturnDate(int checkedBookId, DateTime returnDate)
        {
            try
            {
                var result = await _checkedBookService.UpdateReturnDate(checkedBookId, returnDate);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating return date: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
