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
        Task<IEnumerable<Message>> GetMessagesAsync();
        Task<IEnumerable<Message>> GetUserMessagesAsync(Guid userId);
        Task<IEnumerable<Message>> GetUserMessagesFromChatAsync(Guid userId, Guid chatId);
        Task<IEnumerable<Message>> GetChatMessagesAsync(Guid chatId);
        Task<Message> GetMessageByIdAsync(Guid id, bool trackChanges);
        void UpdateMessage(Message message);
        void DeleteMessage(Message message);
    }
}
