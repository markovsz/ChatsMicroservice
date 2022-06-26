using System;

namespace Messager.Chats.Domain.Core.Models
{
    public class ChatMember
    {
        public Guid Id { get; set; } //useless?
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public DateTime EntryTime { get; set; }

        public Chat UserChat { get; set; }
    }
}
