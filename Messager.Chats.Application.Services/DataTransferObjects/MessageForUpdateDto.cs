using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Application.Services.DataTransferObjects
{
    public class MessageForUpdateDto
    {
        public Guid ChatId { get; set; }
        public string Text { get; set; }
    }
}
