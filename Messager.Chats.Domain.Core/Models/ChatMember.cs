using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Domain.Core.Models
{
    public class ChatMember
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ChatId { get; set; }
    }
}
