using AutoMapper;
using Messager.Chats.Application.Services.DataTransferObjects;
using Messager.Chats.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatsMicroservice
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Chat, ChatForReadDto>();
            CreateMap<ChatForCreateDto, Chat>();
            CreateMap<ChatForUpdateDto, Chat>();

            CreateMap<ChatMember, ChatMemberForReadDto>();
            CreateMap<ChatMemberForCreateDto, ChatMember>();

            CreateMap<Message, MessageForReadDto>();
            CreateMap<MessageForCreateDto, Message>();
            CreateMap<MessageForUpdateDto, Message>();
        }
    }
}
