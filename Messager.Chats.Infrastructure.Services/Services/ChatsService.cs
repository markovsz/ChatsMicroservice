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
    public class ChatsService : IChatsService
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public ChatsService(IRepositoryManager chatMembersManager, IMapper mapper)
        {
            _repositoryManager = chatMembersManager;
            _mapper = mapper;
        }

        public async Task<ChatForReadDto> CreateChatAsync(Guid userId, ChatForCreateDto chatDto)
        {
            var chat = _mapper.Map<Chat>(chatDto);
            await _repositoryManager.Chats.CreateChatAsync(chat);
            await _repositoryManager.SaveAsync();
            var chatMember = new ChatMember(userId, chat.Id);
            await _repositoryManager.ChatMembers.AddChatMemberAsync(chatMember);
            await _repositoryManager.SaveAsync();
            var createdChatDto = _mapper.Map<ChatForReadDto>(chat);
            return createdChatDto;
        }

        public async Task DeleteChatByIdAsync(Guid chatId)
        {
            var chat = await _repositoryManager.Chats.GetChatByIdAsync(chatId, false);
            _repositoryManager.Chats.DeleteChat(chat);
            await _repositoryManager.SaveAsync();
        }

        public async Task<ChatForReadDto> GetChatByIdAsync(Guid chatId)
        {
            var chat = await _repositoryManager.Chats.GetChatByIdAsync(chatId, false);
            var chatDto = _mapper.Map<ChatForReadDto>(chat);
            return chatDto;
        }

        public async Task<IEnumerable<ChatForReadDto>> GetChatsAsync()
        {
            var chats = await _repositoryManager.Chats.GetChatsAsync();
            var chatsDto = _mapper.Map<IEnumerable<ChatForReadDto>>(chats);
            return chatsDto;
        }

        public async Task<IEnumerable<ChatForReadDto>> GetUserChatsAsync(Guid userId)
        {
            var chats = await _repositoryManager.Chats.GetUserChatsAsync(userId);
            var chatsDto = _mapper.Map<IEnumerable<ChatForReadDto>>(chats);
            return chatsDto;
        }

        public async Task JoinChatAsync(Guid userId, string invitationKey)
        {
            var chat = await _repositoryManager.Chats.GetChatByInvitaionKeyAsync(invitationKey);
            var chatMember = new ChatMember(userId, chat.Id);
            await _repositoryManager.ChatMembers.AddChatMemberAsync(chatMember);
            await _repositoryManager.SaveAsync();
        }

        public async Task LeaveChatAsync(Guid userId, Guid chatId)
        {
            var chatMember = await _repositoryManager.ChatMembers.GetChatMemberByUserIdAsync(chatId, userId, false);
            _repositoryManager.ChatMembers.DeleteChatMember(chatMember);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateChat(Guid chatId, ChatForUpdateDto chatDto)
        {
            var chat = _mapper.Map<Chat>(chatDto);
            chat.Id = chatId;
            _repositoryManager.Chats.UpdateChat(chat);
            await _repositoryManager.SaveAsync();
        }
    }
}
