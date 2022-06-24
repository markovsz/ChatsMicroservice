using Messager.Chats.Domain.Interfaces.Repositories.Repository;
using System.Threading.Tasks;

namespace Messager.Chats.Domain.Interfaces.Repositories
{
    public interface IRepositoryManager
    {
        IMessagesRepository Messages { get; }
        IChatsRepository Chats { get; }
        IChatMembersRepository ChatMembers { get; }

        Task SaveAsync();
    }
}
