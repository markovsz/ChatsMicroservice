﻿using Messager.Chats.Domain.Core.Models;
using Messager.Chats.Domain.Interfaces.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Infrastructure.Data.Repository
{
    public class ChatsRepository : RepositoryBase<Chat>, IChatsRepository
    {
        public ChatsRepository(RepositoryContext context)
            : base(context)
        {

        }

        public async Task CreateChatAsync(Chat chat) =>
            await CreateAsync(chat);

        public void DeleteChat(Chat chat) =>
            Delete(chat);

        public async Task<Chat> GetChatByIdAsync(Guid chatId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(chatId), false)
            .FirstOrDefaultAsync();

        public async Task<Chat> GetChatByInvitaionKeyAsync(string invitationKey, bool trackChanges) =>
            await FindByCondition(c => c.InvitationKey.Equals(invitationKey), false)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Chat>> GetChatsAsync(bool trackChanges) =>
            await FindAll(false)
            .ToListAsync();

        public async Task<IEnumerable<Chat>> GetCustomerChatsAsync(Guid customerId, bool trackChanges) =>
            await FindAll(false)
            .Include(c => c.ChatMembers)
            .Where(c => c.ChatMembers.Where(cm => cm.CustomerId.Equals(customerId)).Count() > 0)
            .ToListAsync();

        public void UpdateChat(Chat chat) =>
            Update(chat);
    }
}