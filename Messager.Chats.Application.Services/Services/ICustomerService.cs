using Messager.Chats.Application.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Application.Services.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<MessageForReadDto>> GetChatMessagesAsync(Guid chatId);
        Task<MessageForReadDto> GetMessageByIdAsync(Guid id);
    }
}
