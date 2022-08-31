using AutoMapper;
using Messager.Chats.Application.Services.DataTransferObjects;
using Messager.Chats.Domain.Core.Models;

namespace Messager.Chats.Infrastructure.Services
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
            CreateMap<Message, MessageCreatedForReadDto>();
            CreateMap<MessageForCreateDto, Message>();
            CreateMap<MessageForUpdateDto, Message>();
        }
    }
}
