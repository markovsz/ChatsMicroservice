﻿using Messager.Chats.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Domain.Interfaces.Repositories.CustomerSubsystem
{
    public interface IChatsRepositoryForCustomer
    {
        Task<IEnumerable<Message>> GetChatMessagesAsync(Guid chatId);
        Task<Message> GetMessageByIdAsync(Guid id);
    }
}
