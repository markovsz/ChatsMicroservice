using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Application.Services.DataTransferObjects
{
    public class MessageCreatedForReadDto
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid ChatId { get; set; }
        public string Text { get; set; }
        public DateTime SendingTime { get; set; }
    }
}
