using ChatsMicroservice.Filters;
using Messager.Chats.Application.Services.DataTransferObjects;
using Messager.Chats.Application.Services.Services;
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
    public class ChatsController : ControllerBase
    {
        private IChatsService _chatsService;

        public ChatsController(IChatsService chatsService)
        {
            _chatsService = chatsService;
        }

        [Authorize(Roles = "Customer,Administrator")]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPost("join/{invitationKey}")]
        public async Task<IActionResult> JoinChatAsync(Guid userId, string invitationKey)
        {
            await _chatsService.JoinChatAsync(userId, invitationKey);
            return Ok();
        }

        [Authorize(Roles = "Customer,Administrator")]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPost("leave/{chatId}")]
        public async Task<IActionResult> LeaveChatAsync(Guid userId, Guid chatId)
        {
            await _chatsService.LeaveChatAsync(userId, chatId);
            return Ok();
        }

        [Authorize(Roles = "Customer,Administrator")]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPost()]
        public async Task<IActionResult> CreateChatAsync([FromBody] ChatForCreateDto chatDto, Guid userId)
        {
            var chatId = await _chatsService.CreateChatAsync(userId, chatDto);
            return CreatedAtRoute("GetChat", new { id = chatId });
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("all")]
        public async Task<IActionResult> GetChatsAsync()
        {
            var chats = await _chatsService.GetChatsAsync();
            return Ok(chats);
        }

        [Authorize(Roles = "Customer,Administrator")]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpGet()]
        public async Task<IActionResult> GetUserChatsAуsync(Guid userId)
        {
            var chats = await _chatsService.GetUserChatsAsync(userId);
            return Ok(chats);
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("{chatId}", Name = "GetChat")]
        public async Task<IActionResult> GetChatByIdAsync(Guid chatId)
        {
            var chat = await _chatsService.GetChatByIdAsync(chatId);
            return Ok(chat);
        }

        [Authorize(Roles = "Customer,Administrator")]
        [HttpPut("{chatId}")]
        public async Task<IActionResult> UpdateChat(Guid chatId, ChatForUpdateDto chatDto)
        {
            await _chatsService.UpdateChat(chatId, chatDto);
            return NoContent();
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{chatId}")]
        public async Task<IActionResult> DeleteChatByIdAsync(Guid chatId)
        {
            await _chatsService.DeleteChatByIdAsync(chatId);
            return NoContent();
        }
    }
}
