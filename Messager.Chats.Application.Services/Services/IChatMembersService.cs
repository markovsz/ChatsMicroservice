using Messager.Chats.Application.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Application.Services.Services
{
    public interface IChatMembersService
    {
        Task<ChatMemberForReadDto> AddChatMemberAsync(ChatMemberForCreateDto chatMember);
        Task<IEnumerable<ChatMemberForReadDto>> GetChatMembersAsync(Guid chatId);
        Task<ChatMemberForReadDto> GetChatMemberByUserIdAsync(Guid chatId, Guid userId);
        Task DeleteChatMemberByUserIdAsync(Guid chatId, Guid userId);
        Task DeleteChatMembersByUserIdAsync(Guid userId);
    }
}
