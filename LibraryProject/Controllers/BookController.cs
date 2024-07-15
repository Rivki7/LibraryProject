using Entities.DTO;
using LibraryProjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync
            ()
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();
                if (books != null)
                    return Ok(books);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);
                if (book != null)
                    return Ok(book);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromBody] BookDTO bookDto)
        {
            try
            {
                var addedBook = await _bookService.AddBookAsync(bookDto);
                if (addedBook != null)
                    return CreatedAtAction(nameof(GetBookByIdAsync), new { id = addedBook.Id }, addedBook);
                else
                    return BadRequest("Failed to add book");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookAsync(int id, [FromBody] BookDTO updatedBookDto)
        {
            try
            {
                if (id != updatedBookDto.Id)
                    return BadRequest("ID mismatch");

                var updatedBook = await _bookService.UpdateBookAsync(updatedBookDto);
                if (updatedBook != null)
                    return Ok(updatedBook);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            try
            {
                var result = await _bookService.DeleteBookAsync(id);
                if (result)
                    return NoContent();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
