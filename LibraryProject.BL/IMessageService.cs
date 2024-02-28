using Entities.DTO;

namespace LibraryProjectService
{
    public interface IMessageService
    {
        Task<MessageDTO> AddMessage(MessageDTO messageDTO);
        Task<bool> DeleteMessage(int messageId);
        Task<List<MessageDTO>> GetAllMessages();
        Task<MessageDTO> GetMessageById(int messageId);
        Task<List<MessageDTO>> GetMessagesByUserId(int userId);
        Task<MessageDTO> UpdateMessage(MessageDTO messageDTO);
    }
}