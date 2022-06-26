using AutoMapper;
using Messager.Chats.Application.Services.DataTransferObjects;
using Messager.Chats.Application.Services.Services;
using Messager.Chats.Domain.Core.Models;
using Messager.Chats.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
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

        public async Task CreateMessage(MessageForCreateDto messageDto)
        {
            var message = _mapper.Map<Message>(messageDto);
            await _repositoryManager.Messages.CreateMessageAsync(message);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteMessageByIdAsync(Guid messageId)
        {
            var message = await _repositoryManager.Messages.GetMessageByIdAsync(messageId, false);
            _repositoryManager.Messages.DeleteMessage(message);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<MessageForReadDto>> GetChatMessagesAsync(Guid chatId)
        {
            var messages = await _repositoryManager.Messages.GetChatMessagesAsync(chatId, false);
            var messagesDto = _mapper.Map<IEnumerable<MessageForReadDto>>(messages);
            return messagesDto;
        }

        public async Task<IEnumerable<MessageForReadDto>> GetUserMessagesFromChatAsync(Guid userId, Guid chatId)
        {
            var messages = await _repositoryManager.Messages.GetUserMessagesFromChatAsync(userId, chatId, false);
            var messagesDto = _mapper.Map<IEnumerable<MessageForReadDto>>(messages);
            return messagesDto;
        }

        public async Task<MessageForReadDto> GetMessageByIdAsync(Guid id)
        {
            var message = await _repositoryManager.Messages.GetMessageByIdAsync(id, false);
            var messageDto = _mapper.Map<MessageForReadDto>(message);
            return messageDto;
        }

        public void UpdateMessage(MessageForUpdateDto messageDto)
        {
            var message = _mapper.Map<Message>(messageDto);
            _repositoryManager.Messages.UpdateMessage(message);
            _repositoryManager.SaveAsync();
        }
    }
}
