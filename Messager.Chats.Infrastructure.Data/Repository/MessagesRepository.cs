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
    public class MessagesRepository : RepositoryBase<Message>, IMessagesRepository
    {
        public MessagesRepository(RepositoryContext context)
            : base(context)
        {
        }

        public async Task CreateMessageAsync(Message message) =>
            await CreateAsync(message);

        public void DeleteMessage(Message message) =>
            Delete(message);

        public async Task<IEnumerable<Message>> GetChatMessagesAsync(Guid chatId) =>
            await FindByCondition(m => m.ChatId.Equals(chatId), false)
            .ToListAsync();

        public async Task<IEnumerable<Message>> GetUserMessagesAsync(Guid userId) =>
            await FindByCondition(m => m.SenderId.Equals(userId), false)
            .ToListAsync();

        public async Task<IEnumerable<Message>> GetUserMessagesFromChatAsync(Guid userId, Guid chatId) =>
            await FindByCondition(m => m.ChatId.Equals(chatId)&& m.SenderId.Equals(userId), false)
            .ToListAsync();

        public async Task<Message> GetMessageByIdAsync(Guid id, bool trackChanges) =>
            await FindByCondition(m => m.Id.Equals(id), trackChanges)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Message>> GetMessagesAsync() =>
            await FindAll(false)
            .ToListAsync();

        public void UpdateMessage(Message message) =>
            Update(message);
    }
}
