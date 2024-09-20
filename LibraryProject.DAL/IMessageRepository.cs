
using LibraryProjectRepository.Models;

namespace LibraryProjectRepository
{
    public interface IMessageRepository
    {
        Task<Message> AddMessage(Message message);
        Task<bool> DeleteMessage(int messageId);
        Task<List<Message>> GetAllMessages();
        Task<Message> GetMessageById(int messageId);
        Task<List<Message>> GetMessagesByUserId(int userId);
        Task<Message> UpdateMessage(Message message);
    }
}