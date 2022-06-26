using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Application.Services.DataTransferObjects
{
    public class ChatForUpdateDto
    {
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public string InvitationKey { get; set; }
    }
}
