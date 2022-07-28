using AutoMapper;
using Messager.Chats.Application.Services.DataTransferObjects;
using Messager.Chats.Application.Services.Services;
using Messager.Chats.Domain.Core.Models;
using Messager.Chats.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messager.Chats.Infrastructure.Services.Services
{
    public class MessagesService : IMessagesService
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public MessagesService(IRepositoryManager chatMembersManager, IMapper mapper)
        {
            _repositoryManager = chatMembersManager;
            _mapper = mapper;
        }

        public async Task<MessageCreatedForReadDto> CreateMessageAsync(Guid userId, MessageForCreateDto messageDto)
        {
            var message = _mapper.Map<Message>(messageDto);
            message.SendingTime = DateTime.Now;
            message.SenderId = userId;
            await _repositoryManager.Messages.CreateMessageAsync(message);
            await _repositoryManager.SaveAsync();
            var messageCreatedDto = _mapper.Map<MessageCreatedForReadDto>(message);
            return messageCreatedDto;
        }

        public async Task DeleteMessageByIdAsync(Guid userId, Guid messageId)
        {
            var message = await _repositoryManager.Messages.GetMessageByIdAsync(messageId, false);
            if (!message.SenderId.Equals(userId))
                throw new InvalidOperationException("invalid message to be deleted");
            _repositoryManager.Messages.DeleteMessage(message);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<MessageForReadDto>> GetChatMessagesAsync(Guid chatId)
        {
            var messages = await _repositoryManager.Messages.GetChatMessagesAsync(chatId);
            var messagesDto = _mapper.Map<IEnumerable<MessageForReadDto>>(messages);
            return messagesDto;
        }

        public async Task<IEnumerable<MessageForReadDto>> GetUserMessagesFromChatAsync(Guid userId, Guid chatId)
        {
            var messages = await _repositoryManager.Messages.GetUserMessagesFromChatAsync(userId, chatId);
            var messagesDto = _mapper.Map<IEnumerable<MessageForReadDto>>(messages);
            return messagesDto;
        }

        public async Task<MessageForReadDto> GetMessageByIdAsync(Guid id)
        {
            var message = await _repositoryManager.Messages.GetMessageByIdAsync(id, false);
            var messageDto = _mapper.Map<MessageForReadDto>(message);
            return messageDto;
        }

        public void UpdateMessage(Guid userId, Guid messageId, MessageForUpdateDto messageDto)//TODO: check message userId 
        {
            var message = _mapper.Map<Message>(messageDto);
            message.Id = messageId;
            message.SenderId = userId;
            _repositoryManager.Messages.UpdateMessage(message);
            _repositoryManager.SaveAsync();
        }
    }
}
