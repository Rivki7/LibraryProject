using Entities.DTO;
using LibraryProjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksArchiveController : ControllerBase
    {
        private readonly IBooksArchiveService _booksArchiveService;

        public BooksArchiveController(IBooksArchiveService booksArchiveService)
        {
            _booksArchiveService = booksArchiveService;
        }

        [HttpPost]
        public async Task<ActionResult<BooksArchiveDTO>> AddBooksArchive(BooksArchiveDTO booksArchiveDTO)
        {
            var addedBooksArchive = await _booksArchiveService.AddBooksArchive(booksArchiveDTO);
            if (addedBooksArchive == null)
            {
                return BadRequest();
            }
            return addedBooksArchive;
        }

        [HttpGet]
        public async Task<ActionResult<List<BooksArchiveDTO>>> GetAllBooksArchive()
        {
            var booksArchives = await _booksArchiveService.GetAllBooksArchive();
            if (booksArchives == null)
            {
                return NotFound();
            }
            return booksArchives;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BooksArchiveDTO>> GetBooksArchiveById(int id)
        {
            var booksArchive = await _booksArchiveService.GetBooksArchiveById(id);
            if (booksArchive == null)
            {
                return NotFound();
            }
            return booksArchive;
        }
    }
}
