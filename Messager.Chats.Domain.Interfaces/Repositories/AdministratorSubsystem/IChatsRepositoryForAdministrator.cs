using Messager.Chats.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Domain.Interfaces.Repositories.AdministratorSubsystem
{
    public interface IChatsRepositoryForAdministrator
    {
        Task<IEnumerable<Message>> GetMessagesAsync();
        Task<IEnumerable<Message>> GetCustomerMessagesAsync(Guid customerId);
        Task<IEnumerable<Message>> GetChatMessagesAsync(Guid chatId);
        Task<Message> GetMessageByIdAsync(Guid id);
    }
}
