using Messager.Chats.Application.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messager.Chats.Application.Services.Services
{
    public interface IMessagesService
    {
        Task<MessageCreatedForReadDto> CreateMessageAsync(Guid userId, MessageForCreateDto messageDto); //CreatedMessageDto
        Task<IEnumerable<MessageForReadDto>> GetUserMessagesFromChatAsync(Guid userId, Guid chatId);
        Task<IEnumerable<MessageForReadDto>> GetChatMessagesAsync(Guid chatId);
        Task<MessageForReadDto> GetMessageByIdAsync(Guid id);
        void UpdateMessage(Guid userId, Guid messageId, MessageForUpdateDto messageDto);
        Task DeleteMessageByIdAsync(Guid userId, Guid messageId);
    }
}
