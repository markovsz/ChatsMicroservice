using Messager.Chats.Application.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messager.Chats.Application.Services.Services
{
    public interface IMessagesService
    {
        Task CreateMessage(MessageForCreateDto messageDto);
        Task<IEnumerable<MessageForReadDto>> GetCustomerMessagesFromChatAsync(Guid customerId, Guid chatId);
        Task<IEnumerable<MessageForReadDto>> GetChatMessagesAsync(Guid chatId);
        Task<MessageForReadDto> GetMessageByIdAsync(Guid id);
        void UpdateMessage(MessageForUpdateDto messageDto);
        Task DeleteMessageByIdAsync(Guid messageId);
    }
}
