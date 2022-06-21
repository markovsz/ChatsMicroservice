using System;
using System.Threading.Tasks;

namespace Messager.Chats.Domain.Interfaces.Repositories.AdministratorSubsystem
{
    public interface IAdministratorManager
    {
        IChatsRepositoryForAdministrator Chats { get; set; }
        Task SaveAsync();
    }
}