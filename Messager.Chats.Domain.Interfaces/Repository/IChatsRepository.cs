using Messager.Chats.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Domain.Interfaces.Repositories.Repository
{
    public interface IChatsRepository
    {
        Task CreateChatAsync(Chat chat);
        Task<IEnumerable<Chat>> GetChatsAsync(bool trackChanges);
        Task<IEnumerable<Chat>> GetUserChatsAsync(Guid userId, bool trackChanges);
        Task<Chat> GetChatByIdAsync(Guid chatId, bool trackChanges);
        Task<Chat> GetChatByInvitaionKeyAsync(string invitationKey, bool trackChanges);
        void UpdateChat(Chat chat);
        void DeleteChat(Chat chat);
    }
}
