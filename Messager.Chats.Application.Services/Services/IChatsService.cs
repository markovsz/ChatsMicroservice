using Messager.Chats.Application.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messager.Chats.Application.Services.Services
{
    public interface IChatsService
    {
        Task JoinChatAsync(Guid userId, string invitationKey);
        Task LeaveChatAsync(Guid userId, Guid chatId);
        Task<Guid> CreateChatAsync(ChatForReadDto chatDto);
        Task<IEnumerable<ChatForReadDto>> GetChatsAsync();
        Task<IEnumerable<ChatForReadDto>> GetUserChatsAsync(Guid userId);
        Task<ChatForReadDto> GetChatByIdAsync(Guid chatId);
        Task UpdateChat(Guid chatId, ChatForUpdateDto chatDto);
        Task DeleteChatByIdAsync(Guid chatId);
    }
}
