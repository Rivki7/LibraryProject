using Entities.DTO;
using LibraryProjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MessageDTO>>> GetAllMessages()
        {
            try
            {
                var messages = await _messageService.GetAllMessages();
                if (messages == null)
                    return NotFound();

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDTO>> GetMessageById(int id)
        {
            try
            {
                var message = await _messageService.GetMessageById(id);
                if (message == null)
                    return NotFound();

                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<MessageDTO>>> GetMessagesByUserId(int userId)
        {
            try
            {
                var messages = await _messageService.GetMessagesByUserId(userId);
                if (messages == null)
                    return NotFound();

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<MessageDTO>> AddMessage(MessageDTO messageDTO)
        {
            try
            {
                var addedMessage = await _messageService.AddMessage(messageDTO);
                if (addedMessage == null)
                    return BadRequest();

                return CreatedAtAction(nameof(GetMessageById), new { id = addedMessage.Id }, addedMessage);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MessageDTO>> UpdateMessage(int id, MessageDTO messageDTO)
        {
            try
            {
                if (id != messageDTO.Id)
                    return BadRequest("Id mismatch");

                var updatedMessage = await _messageService.UpdateMessage(messageDTO);
                if (updatedMessage == null)
                    return NotFound();

                return Ok(updatedMessage);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMessage(int id)
        {
            try
            {
                var result = await _messageService.DeleteMessage(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
