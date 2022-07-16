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
        Task<IEnumerable<Chat>> GetChatsAsync();
        Task<IEnumerable<Chat>> GetChatsIncludePrivateAsync();
        Task<IEnumerable<Chat>> GetUserChatsAsync(Guid userId);
        Task<Chat> GetChatByIdAsync(Guid chatId, bool trackChanges);
        Task<Chat> GetChatByIdIncludePrivateAsync(Guid chatId, bool trackChanges);
        Task<Chat> GetChatByInvitaionKeyAsync(string invitationKey);
        void UpdateChat(Chat chat);
        void DeleteChat(Chat chat);
    }
}
