using Messager.Chats.Domain.Core.Models;
using Messager.Chats.Domain.Interfaces.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Infrastructure.Data.Repository
{
    public class ChatMembersRepository : RepositoryBase<ChatMember>, IChatMembersRepository
    {
        public ChatMembersRepository(RepositoryContext context)
            : base(context)
        {
        }

        public async Task AddChatMemberAsync(ChatMember chatMember) =>
            await CreateAsync(chatMember);

        public void DeleteChatMember(ChatMember chatMember) =>
            Delete(chatMember);

        public async Task<IEnumerable<ChatMember>> GetChatMembersAsync(Guid chatId) =>
            await FindByCondition(cm => cm.ChatId.Equals(chatId), false)
            .ToListAsync();

        public async Task<ChatMember> GetChatMemberByUserIdAsync(Guid chatId, Guid userId, bool trackChanges) =>
            await FindByCondition(cm => cm.UserId.Equals(userId) && cm.ChatId.Equals(chatId), trackChanges)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<ChatMember>> GetChatMembersByUserIdAsync(Guid userId) =>
            await FindByCondition(cm => cm.UserId.Equals(userId), false)
            .ToListAsync();
    }
}
