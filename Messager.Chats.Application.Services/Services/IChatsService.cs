using Messager.Chats.Application.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messager.Chats.Application.Services.Services
{
    public interface IChatsService
    {
        Task JoinChatAsync(Guid customerId, string invitationKey);
        Task LeaveChatAsync(Guid customerId, Guid chatId);
        Task<Guid> CreateChatAsync(ChatForReadDto chatDto);
        Task<IEnumerable<ChatForReadDto>> GetChatsAsync();
        Task<IEnumerable<ChatForReadDto>> GetCustomerChatsAsync(Guid customerId);
        Task<ChatForReadDto> GetChatByIdAsync(Guid chatId);
        Task UpdateChat(Guid chatId, ChatForUpdateDto chatDto);
        Task DeleteChatByIdAsync(Guid chatId);
    }
}
