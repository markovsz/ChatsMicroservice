using Messager.Chats.Domain.Interfaces.Repositories;
using Messager.Chats.Domain.Interfaces.Repositories.Repository;
using Messager.Chats.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Infrastructure.Data
{
    public class RepositoryManager : IRepositoryManager
    {
        private IMessagesRepository _messagesRepository;
        private IChatsRepository _chatsRepository;
        private IChatMembersRepository _chatMembersRepository;
        private RepositoryContext _context;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
        }

        public IMessagesRepository Messages
        {
            get
            {
                if (_messagesRepository is null)
                    _messagesRepository = new MessagesRepository(_context);
                return _messagesRepository;
            }   
        }

        public IChatsRepository Chats
        {
            get
            {
                if (_chatsRepository is null)
                    _chatsRepository = new ChatsRepository(_context);
                return _chatsRepository;
            }
        }

        public IChatMembersRepository ChatMembers
        {
            get
            {
                if (_chatMembersRepository is null)
                    _chatMembersRepository = new ChatMembersRepository(_context);
                return _chatMembersRepository;
            }
        }

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();
    }
}
