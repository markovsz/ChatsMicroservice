using Messager.Chats.Application.Services.DataTransferObjects;
using Messager.Chats.Infrastructure.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMembersController : ControllerBase
    {
        private ChatMembersService _chatMembersService;

        public ChatMembersController(ChatMembersService chatMembersService)
        {
            _chatMembersService = chatMembersService;
        }

        [Authorize(Roles = "Customer,Administrator")]
        [HttpPost()]
        public async Task<IActionResult> AddChatMemberAsync(ChatMemberForCreateDto chatMember)
        {
            var chatMemberId = await _chatMembersService.AddChatMemberAsync(chatMember);
            return CreatedAtRoute("GetChatMember", new { id = chatMemberId });
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
        public async Task<IActionResult> GetChatMemberByUserIdAsync(Guid chatId, Guid userId, bool trackChanges)
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
