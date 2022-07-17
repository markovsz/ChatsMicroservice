using Messager.Chats.API.Filters;
using Messager.Chats.Application.Services.DataTransferObjects;
using Messager.Chats.Application.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messager.Chats.API.Controllers
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
            var createdChatDto = await _chatsService.CreateChatAsync(userId, chatDto);
            //var res = CreatedAtAction("GetChat", new { chatId = chatId });
            return Created($"api/Chats/{createdChatDto.Id}", createdChatDto);
        }

        [Authorize(Roles = "Customer,Administrator")]
        [ServiceFilter(typeof(ExtractRoleFilter))]
        [HttpGet("all")]
        public async Task<IActionResult> GetChatsAsync(string userRole)
        {
            IEnumerable<ChatForReadDto> chats = null;
            if (userRole.Equals("Customer"))
                chats = await _chatsService.GetChatsAsync();
            else if (userRole.Equals("Administrator"))
                chats = await _chatsService.GetChatsIncludePrivateAsync();
            return Ok(chats);
        }


        [Authorize(Roles = "Customer,Administrator")]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpGet()]
        public async Task<IActionResult> GetUserChatsAsync(Guid userId)
        {
            var chats = await _chatsService.GetUserChatsAsync(userId);
            return Ok(chats);
        }


        [Authorize(Roles = "Customer,Administrator")]
        [ServiceFilter(typeof(ExtractRoleFilter))]
        [HttpGet("{chatId}", Name = "GetChat")]
        public async Task<IActionResult> GetChatByIdAsync(Guid chatId, string userRole)
        {
            ChatForReadDto chat = null; 
            if(userRole.Equals("Customer"))
                chat = await _chatsService.GetChatByIdAsync(chatId);
            else if(userRole.Equals("Administrator"))
                chat = await _chatsService.GetChatByIdIncludePrivateAsync(chatId);
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
