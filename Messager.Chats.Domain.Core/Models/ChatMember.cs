using System;

namespace Messager.Chats.Domain.Core.Models
{
    public class ChatMember
    {
        public ChatMember()
        {
        }

        public ChatMember(Guid userId, Guid chatId)
        {
            UserId = userId;
            ChatId = chatId;
            EntryTime = DateTime.Now;
        }

        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public DateTime EntryTime { get; set; }

        public Chat UserChat { get; set; }
    }
}
