using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Domain.Interfaces.Repositories.CustomerSubsystem
{
    public interface ICustomerRepository
    {
        IChatsRepositoryForCustomer Chats { get; set; }
        Task SaveAsync();
    }
}
