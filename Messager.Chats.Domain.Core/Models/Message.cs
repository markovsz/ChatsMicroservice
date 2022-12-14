using System;

namespace Messager.Chats.Domain.Core.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; } //user id
        public Guid ChatId { get; set; }
        public string Text { get; set; }
        public DateTime SendingTime { get; set; }

        public Chat MessageChat { get; set; }
    }
}