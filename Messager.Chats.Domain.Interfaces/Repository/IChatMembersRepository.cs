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
        Task<IEnumerable<ChatMember>> GetChatMembersAsync(Guid chatId, bool trackChanges);
        Task<ChatMember> GetChatMemberByUserIdAsync(Guid userId, bool trackChanges);
        void DeleteChatMember(ChatMember chatMember);
    }
}
