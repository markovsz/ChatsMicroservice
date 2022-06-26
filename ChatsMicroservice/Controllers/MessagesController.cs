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
    public class MessagesController : ControllerBase
    {
        private IMessagesService _messagesService;

        public MessagesController(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateMessageAsync(MessageForCreateDto messageDto)
        {
            var messageId = await _messagesService.CreateMessageAsync(messageDto);
            return CreatedAtRoute("GetMessage", new { id = messageId });
        }

        [HttpGet("chat/{chatId}/member/{userId}")]
        public async Task<IActionResult> GetUserMessagesFromChatAsync(Guid userId, Guid chatId)
        {
            var messages = await _messagesService.GetUserMessagesFromChatAsync(userId, chatId);
            return Ok(messages);
        }

        [HttpGet("chat/{chatId}")]
        public async Task<IActionResult> GetChatMessagesAsync(Guid chatId)
        {
            var messages = await _messagesService.GetChatMessagesAsync(chatId);
            return Ok(messages);
        }

        [HttpGet("{messageId}", Name = "GetMessage")]
        public async Task<IActionResult> GetMessageByIdAsync(Guid messageId)
        {
            var message = await _messagesService.GetMessageByIdAsync(messageId);
            return Ok(message);
        }

        [HttpPut("{messageId}")]
        public IActionResult UpdateMessage(Guid messageId, MessageForUpdateDto messageDto)
        {
            _messagesService.UpdateMessage(messageId, messageDto);
            return NoContent();
        }

        [HttpDelete("{messageId}")]
        public async Task<IActionResult> DeleteMessageByIdAsync(Guid messageId)
        {
            await _messagesService.DeleteMessageByIdAsync(messageId);
            return NoContent();
        }
    }
}
