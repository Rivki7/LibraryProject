using Entities.DTO;
using LibraryProjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrarianController : ControllerBase
    {
        private readonly ILibrarianService _librarianService;

        public LibrarianController(ILibrarianService librarianService)
        {
            _librarianService = librarianService;
        }

        [HttpPost]
        public async Task<ActionResult<LibrariansDTO>> AddLibrarian(LibrariansDTO newLibrarianDTO)
        {
            try
            {
                var addedLibrarian = await _librarianService.AddLibrarian(newLibrarianDTO);
                if (addedLibrarian == null)
                {
                    return BadRequest();
                }
                return CreatedAtAction(nameof(AddLibrarian), addedLibrarian);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while adding librarian: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<LibrariansDTO>>> GetAllLibrarians()
        {
            try
            {
                var librarians = await _librarianService.GetAllLibrarians();
                if (librarians == null)
                {
                    return NotFound();
                }
                return Ok(librarians);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting all librarians: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{librarianId}")]
        public async Task<ActionResult<LibrariansDTO>> GetLibrarianById(int librarianId)
        {
            try
            {
                var librarian = await _librarianService.GetLibrarianById(librarianId);
                if (librarian == null)
                {
                    return NotFound();
                }
                return Ok(librarian);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting librarian by ID: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{librarianId}")]
        public async Task<ActionResult> UpdateLibrarian(int librarianId, LibrariansDTO updatedLibrarianDTO)
        {
            try
            {
                var result = await _librarianService.UpdateLibrarian(updatedLibrarianDTO);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating librarian: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{librarianId}")]
        public async Task<ActionResult> DeleteLibrarian(int librarianId)
        {
            try
            {
                var result = await _librarianService.DeleteLibrarian(librarianId);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting librarian: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
