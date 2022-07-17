using Messager.Chats.API.Filters;
using Messager.Chats.Application.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Messager.Chats.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatedEntitiesController : ControllerBase
    {
        IChatMembersService _chatMembersService;

        public RelatedEntitiesController(IChatMembersService chatMembersService)
        {
            _chatMembersService = chatMembersService;
        }


        [Authorize(Roles = "Administrator,Customer")]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpDelete("")]
        public async Task<IActionResult> DeleteUserRelatedEntities(Guid userId)
        {
            await _chatMembersService.DeleteChatMembersByUserIdAsync(userId);
            return NoContent();
        }
    }
}
