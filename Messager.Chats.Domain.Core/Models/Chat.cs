using System;
using System.Collections.Generic;

namespace Messager.Chats.Domain.Core.Models
{
    public class Chat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string InvitationKey { get; set; }

        public IEnumerable<Message> ChatMessages { get; set; }
        public IEnumerable<ChatMember> ChatMembers { get; set; }
    }
}
