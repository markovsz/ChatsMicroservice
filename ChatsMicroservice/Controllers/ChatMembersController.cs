using Messager.Chats.Application.Services.DataTransferObjects;
using Messager.Chats.Application.Services.Services;
using Messager.Chats.Infrastructure.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Messager.Chats.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMembersController : ControllerBase
    {
        private IChatMembersService _chatMembersService;

        public ChatMembersController(IChatMembersService chatMembersService)
        {
            _chatMembersService = chatMembersService;
        }

        [Authorize(Roles = "Customer,Administrator")]
        [HttpPost()]
        public async Task<IActionResult> AddChatMemberAsync(ChatMemberForCreateDto chatMemberDto)
        {
            var chatMemberCreatedDto = await _chatMembersService.AddChatMemberAsync(chatMemberDto);
            return Created($"api/ChatMembers/chat/{chatMemberCreatedDto.ChatId}/member/{chatMemberCreatedDto.UserId}", chatMemberCreatedDto);
        }

        [Authorize(Roles = "Customer,Administrator")]
        [HttpGet("chat/{chatId}")]
        public async Task<IActionResult> GetChatMembersAsync(Guid chatId)
        {
            var chatMembers = await _chatMembersService.GetChatMembersAsync(chatId);
            return Ok(chatMembers);
        }

        [Authorize(Roles = "Customer,Administrator")]
        [HttpGet("/chat/{chatId}/member/{userId}", Name = "GetChatMember")]
        public async Task<IActionResult> GetChatMemberByUserIdAsync(Guid chatId, Guid userId)
        {
            var chatMember = await _chatMembersService.GetChatMemberByUserIdAsync(chatId, userId);
            return Ok(chatMember);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("/chat/{chatId}/member/{userId}")]
        public async Task<IActionResult> DeleteChatMemberByUserIdAsync(Guid chatId, Guid userId)
        {
            await _chatMembersService.DeleteChatMemberByUserIdAsync(chatId, userId);
            return NoContent();
        }
    }
}
