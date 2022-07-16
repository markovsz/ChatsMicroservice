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
    public class ChatMembersService : IChatMembersService
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public ChatMembersService(IRepositoryManager chatMembersManager, IMapper mapper)
        {
            _repositoryManager = chatMembersManager;
            _mapper = mapper;
        }

        public async Task<ChatMemberForReadDto> AddChatMemberAsync(ChatMemberForCreateDto chatMemberDto)
        {
            var chatMember = _mapper.Map<ChatMember>(chatMemberDto);
            chatMember.EntryTime = DateTime.Now;
            await _repositoryManager.ChatMembers.AddChatMemberAsync(chatMember);
            await _repositoryManager.SaveAsync();
            var chatMemberCreatedDto = _mapper.Map<ChatMemberForReadDto>(chatMember);
            return chatMemberCreatedDto;
        }

        public async Task DeleteChatMemberByUserIdAsync(Guid chatId, Guid userId)
        {
            var chatMember = await _repositoryManager.ChatMembers.GetChatMemberByUserIdAsync(chatId, userId, false);
            _repositoryManager.ChatMembers.DeleteChatMember(chatMember);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteChatMembersByUserIdAsync(Guid userId)
        {
            var chatMembers = await _repositoryManager.ChatMembers.GetChatMembersByUserIdAsync(userId);
            foreach(var chatMember in chatMembers)
                _repositoryManager.ChatMembers.DeleteChatMember(chatMember);
            await _repositoryManager.SaveAsync();
        }

        public async Task<ChatMemberForReadDto> GetChatMemberByUserIdAsync(Guid chatId, Guid userId)
        {
            var chatMember = await _repositoryManager.ChatMembers.GetChatMemberByUserIdAsync(chatId, userId, false);
            var chatMemberDto = _mapper.Map<ChatMemberForReadDto>(chatMember);
            return chatMemberDto;
        }

        public async Task<IEnumerable<ChatMemberForReadDto>> GetChatMembersAsync(Guid chatId)
        {
            var chatMember = await _repositoryManager.ChatMembers.GetChatMembersAsync(chatId);
            var chatMemberDto = _mapper.Map<IEnumerable<ChatMemberForReadDto>>(chatMember);
            return chatMemberDto;
        }
    }
}
