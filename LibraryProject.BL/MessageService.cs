using AutoMapper;
using Entities.DTO;
using LibraryProjectRepository;
using LibraryProjectRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectService
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<List<MessageDTO>> GetAllMessages()
        {
            try
            {
                var messages = await _messageRepository.GetAllMessages();
                return _mapper.Map<List<MessageDTO>>(messages);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllMessagesAsync in MessageService: {ex.Message}");
                return null;
            }
        }

        public async Task<MessageDTO> GetMessageById(int messageId)
        {
            try
            {
                var message = await _messageRepository.GetMessageById(messageId);
                return _mapper.Map<MessageDTO>(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMessageByIdAsync in MessageService: {ex.Message}");
                return null;
            }
        }

        public async Task<List<MessageDTO>> GetMessagesByUserId(int userId)
        {
            try
            {
                var messages = await _messageRepository.GetMessagesByUserId(userId);
                return _mapper.Map<List<MessageDTO>>(messages);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMessagesByUserIdAsync in MessageService: {ex.Message}");
                return null;
            }
        }

        public async Task<MessageDTO> AddMessage(MessageDTO messageDTO)
        {
            try
            {
                var message = _mapper.Map<Message>(messageDTO);
                message.Date = DateTime.Now;
                var addedMessage = await _messageRepository.AddMessage(message);
                return _mapper.Map<MessageDTO>(addedMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddMessageAsync in MessageService: {ex.Message}");
                return null;
            }
        }

        public async Task<MessageDTO> UpdateMessage(MessageDTO messageDTO)
        {
            try
            {
                var message = _mapper.Map<Message>(messageDTO);
                var updatedMessage = await _messageRepository.UpdateMessage(message);
                return _mapper.Map<MessageDTO>(updatedMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateMessageAsync in MessageService: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteMessage(int messageId)
        {
            try
            {
                return await _messageRepository.DeleteMessage(messageId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteMessageAsync in MessageService: {ex.Message}");
                return false;
            }
        }
    }
}
