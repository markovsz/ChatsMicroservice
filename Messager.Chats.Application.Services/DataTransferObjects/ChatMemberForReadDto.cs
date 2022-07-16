using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Application.Services.DataTransferObjects
{
    public class ChatMemberForReadDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public DateTime EntryTime { get; set; }
    }
}
