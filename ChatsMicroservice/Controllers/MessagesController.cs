using Messager.Chats.API.Filters;
using Messager.Chats.Application.Services.DataTransferObjects;
using Messager.Chats.Application.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Messager.Chats.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private IMessagesService _messagesService;

        public MessagesController(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        [Authorize(Roles = "Customer,Administrator")]
        [HttpPost()]
        public async Task<IActionResult> CreateMessageAsync(MessageForCreateDto messageDto)
        {
            var messageCreatedDto = await _messagesService.CreateMessageAsync(messageDto);
            return Created($"api/Messages/{messageCreatedDto.Id}", messageCreatedDto);
        }

        [Authorize(Roles = "Customer,Administrator")]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpGet("chat/{chatId}/member/{userId}")]
        public async Task<IActionResult> GetUserMessagesFromChatAsync(Guid userId, Guid chatId)
        {
            var messages = await _messagesService.GetUserMessagesFromChatAsync(userId, chatId);
            return Ok(messages);
        }

        [Authorize(Roles = "Customer,Administrator")]
        [HttpGet("chat/{chatId}")]
        public async Task<IActionResult> GetChatMessagesAsync(Guid chatId)
        {
            var messages = await _messagesService.GetChatMessagesAsync(chatId);
            return Ok(messages);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("{messageId}", Name = "GetMessage")]
        public async Task<IActionResult> GetMessageByIdAsync(Guid messageId)
        {
            var message = await _messagesService.GetMessageByIdAsync(messageId);
            return Ok(message);
        }

        [Authorize(Roles = "Customer")]
        [HttpPut("{messageId}")]
        public IActionResult UpdateMessage(Guid messageId, MessageForUpdateDto messageDto)
        {
            _messagesService.UpdateMessage(messageId, messageDto);
            return NoContent();
        }

        [Authorize(Roles = "Customer,Administrator")]
        [HttpDelete("{messageId}")]
        public async Task<IActionResult> DeleteMessageByIdAsync(Guid messageId)
        {
            await _messagesService.DeleteMessageByIdAsync(messageId);
            return NoContent();
        }
    }
}
