using Messager.Chats.Application.Services.DataTransferObjects;
using Messager.Chats.Application.Services.Services;
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

        [HttpPost("join/{invitationKey}")]
        public async Task<IActionResult> JoinChatAsync(Guid userId, string invitationKey)
        {
            await _chatsService.JoinChatAsync(userId, invitationKey);
            return Ok();
        }

        [HttpPost("leave/{chatId}")]
        public async Task<IActionResult> LeaveChatAsync(Guid userId, Guid chatId)
        {
            await _chatsService.LeaveChatAsync(userId, chatId);
            return Ok();
        }

        [HttpPost()]
        public async Task<IActionResult> CreateChatAsync([FromBody] ChatForReadDto chatDto, Guid userId)
        {
            var chatId = await _chatsService.CreateChatAsync(chatDto);
            return CreatedAtRoute("GetChat", new { id = chatId });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetChatsAsync()
        {
            var chats = await _chatsService.GetChatsAsync();
            return Ok(chats);
        }


        [HttpGet()]
        public async Task<IActionResult> GetUserChatsAsync(Guid userId)
        {
            var chats = await _chatsService.GetUserChatsAsync(userId);
            return Ok(chats);
        }


        [HttpGet("{chatId}", Name = "GetChat")]
        public async Task<IActionResult> GetChatByIdAsync(Guid chatId)
        {
            var chat = await _chatsService.GetChatByIdAsync(chatId);
            return Ok(chat);
        }

        [HttpPut("{chatId}")]
        public async Task<IActionResult> UpdateChat(Guid chatId, ChatForUpdateDto chatDto)
        {
            await _chatsService.UpdateChat(chatId, chatDto);
            return NoContent();
        }

        [HttpDelete("{chatId}")]
        public async Task<IActionResult> DeleteChatByIdAsync(Guid chatId)
        {
            await _chatsService.DeleteChatByIdAsync(chatId);
            return NoContent();
        }
    }
}
