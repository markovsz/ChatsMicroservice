using System;

namespace Messager.Chats.Domain.Core.Models
{
    public class ChatMember
    {
        public Guid Id { get; set; } //useless?
        public Guid CustomerId { get; set; }
        public Guid ChatId { get; set; }
        public DateTime EntryTime { get; set; }

        public Chat CustomerChat { get; set; }
    }
}
