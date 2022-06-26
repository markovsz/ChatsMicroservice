using Messager.Chats.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Domain.Interfaces.Repositories.Repository
{
    public interface IMessagesRepository
    {
        Task CreateMessageAsync(Message message);
        Task<IEnumerable<Message>> GetMessagesAsync(bool trackChanges);
        Task<IEnumerable<Message>> GetUserMessagesAsync(Guid userId, bool trackChanges);
        Task<IEnumerable<Message>> GetUserMessagesFromChatAsync(Guid userId, Guid chatId, bool trackChanges);
        Task<IEnumerable<Message>> GetChatMessagesAsync(Guid chatId, bool trackChanges);
        Task<Message> GetMessageByIdAsync(Guid id, bool trackChanges);
        void UpdateMessage(Message message);
        void DeleteMessage(Message message);
    }
}
