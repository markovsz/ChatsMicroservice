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

        public async Task AddChatMemberAsync(ChatMemberForCreateDto chatMemberDto)
        {
            var chatMember = _mapper.Map<ChatMember>(chatMemberDto);
            await _repositoryManager.ChatMembers.AddChatMemberAsync(chatMember);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteChatMemberByCustomerIdAsync(Guid customerId)
        {
            var chatMember = await _repositoryManager.ChatMembers.GetChatMemberByCustomerIdAsync(customerId, false);
            _repositoryManager.ChatMembers.DeleteChatMember(chatMember);
            await _repositoryManager.SaveAsync();
        }

        public async Task<ChatMemberForReadDto> GetChatMemberByCustomerIdAsync(Guid customerId)
        {
            var chatMember = await _repositoryManager.ChatMembers.GetChatMemberByCustomerIdAsync(customerId, false);
            var chatMemberDto = _mapper.Map<ChatMemberForReadDto>(chatMember);
            return chatMemberDto;
        }

        public async Task<IEnumerable<ChatMemberForReadDto>> GetChatMembersAsync(Guid chatId)
        {
            var chatMember = await _repositoryManager.ChatMembers.GetChatMembersAsync(chatId, false);
            var chatMemberDto = _mapper.Map<IEnumerable<ChatMemberForReadDto>>(chatMember);
            return chatMemberDto;
        }
    }
}
