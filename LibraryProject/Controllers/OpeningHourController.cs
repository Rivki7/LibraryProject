using Entities.DTO;
using LibraryProjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningHourController : ControllerBase
    {
        private IOpeningHourService _openingHourService;

        public OpeningHourController(IOpeningHourService openingHourService)
        {
            _openingHourService = openingHourService;
        }

        [HttpGet]
        [Route("getAllOpeningHours")]
        public async Task<ActionResult<List<OpeningHourDTO>>> getAllOpeningHours()
        {
            try
            {
                List<OpeningHourDTO> openingHours = await _openingHourService.GetAllOpeningHours();

                if (openingHours != null && openingHours.Any())
                {
                    return Ok(openingHours);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPut]
        [Route("updateOpeningHours")]
        public async Task<ActionResult<OpeningHourDTO>> UpdateEvent([FromBody] OpeningHourDTO updatedOpeningHourDto)
        {
            try
            {
                OpeningHourDTO resultOpeningHourDto = await _openingHourService.UpdateOpeningHour(updatedOpeningHourDto);

                if (resultOpeningHourDto != null)
                {
                    return Ok(resultOpeningHourDto);
                }
                else
                {
                    return NotFound("Event not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
