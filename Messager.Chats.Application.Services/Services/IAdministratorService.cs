using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messager.Chats.Application.Services.DataTransferObjects;

namespace Messager.Chats.Application.Services.Services
{
    public interface IAdministratorService
    {
        Task<IEnumerable<MessageForReadDto>> GetMessagesAsync();
        Task<IEnumerable<MessageForReadDto>> GetCustomerMessagesAsync(Guid customerId);
        Task<IEnumerable<MessageForReadDto>> GetChatMessagesAsync(Guid chatId);
        Task<MessageForReadDto> GetMessageByIdAsync(Guid id);
    }
}
