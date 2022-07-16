using Messager.Chats.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Domain.Interfaces.Repositories.Repository
{
    public interface IChatMembersRepository
    {
        Task AddChatMemberAsync(ChatMember chatMember);
        Task<IEnumerable<ChatMember>> GetChatMembersAsync(Guid chatId);
        Task<ChatMember> GetChatMemberByUserIdAsync(Guid chatId, Guid userId, bool trackChanges);
        Task<IEnumerable<ChatMember>> GetChatMembersByUserIdAsync(Guid userId);
        void DeleteChatMember(ChatMember chatMember);
    }
}
