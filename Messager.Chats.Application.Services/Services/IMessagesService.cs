using Messager.Chats.Application.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messager.Chats.Application.Services.Services
{
    public interface IMessagesService
    {
        Task<Guid> CreateMessageAsync(MessageForCreateDto messageDto);
        Task<IEnumerable<MessageForReadDto>> GetUserMessagesFromChatAsync(Guid userId, Guid chatId);
        Task<IEnumerable<MessageForReadDto>> GetChatMessagesAsync(Guid chatId);
        Task<MessageForReadDto> GetMessageByIdAsync(Guid id);
        void UpdateMessage(Guid messageId, MessageForUpdateDto messageDto);
        Task DeleteMessageByIdAsync(Guid messageId);
    }
}
