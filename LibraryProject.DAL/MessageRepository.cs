using LibraryProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly LibraryContext _libraryContext;

        public MessageRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<List<Message>> GetAllMessages()
        {
            try
            {
                return await _libraryContext.Messages.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllMessagesAsync in MessageRepository: {ex.Message}");
                return null;
            }
        }

        public async Task<Message> GetMessageById(int messageId)
        {
            try
            {
                return await _libraryContext.Messages.FirstOrDefaultAsync(m => m.Id == messageId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMessageByIdAsync in MessageRepository: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Message>> GetMessagesByUserId(int userId)
        {
            try
            {
                return await _libraryContext.Messages.Where(m => m.UserId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMessagesByUserIdAsync in MessageRepository: {ex.Message}");
                return null;
            }
        }

        public async Task<Message> AddMessage(Message message)
        {
            try
            {
                message.Date = DateTime.Now; // Set the current date
                _libraryContext.Messages.Add(message);
                await _libraryContext.SaveChangesAsync();
                return message;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddMessageAsync in MessageRepository: {ex.Message}");
                return null;
            }
        }

        public async Task<Message> UpdateMessage(Message message)
        {
            try
            {
                _libraryContext.Entry(message).State = EntityState.Modified;
                await _libraryContext.SaveChangesAsync();
                return message;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateMessageAsync in MessageRepository: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteMessage(int messageId)
        {
            try
            {
                var message = await GetMessageById(messageId);
                if (message != null)
                {
                    _libraryContext.Messages.Remove(message);
                    await _libraryContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteMessageAsync in MessageRepository: {ex.Message}");
                return false;
            }
        }
    }
}
