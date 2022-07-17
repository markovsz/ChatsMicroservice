using AutoMapper;
using Messager.Chats.Application.Services.DataTransferObjects;
using Messager.Chats.Domain.Core.Models;

namespace Messager.Chats.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Chat, ChatForReadDto>();
            CreateMap<ChatForCreateDto, Chat>()
                .ForMember(c => c.IsPrivate, c => c.Ignore())
                .BeforeMap((cd, c) => c.IsPrivate = (cd.IsPrivate.Equals("true") ? true : false));
            CreateMap<ChatForUpdateDto, Chat>()
                .ForMember(c => c.IsPrivate, c => c.Ignore())
                .BeforeMap((cd, c) => c.IsPrivate = (cd.IsPrivate.Equals("true") ? true : false));

            CreateMap<ChatMember, ChatMemberForReadDto>();
            CreateMap<ChatMemberForCreateDto, ChatMember>();

            CreateMap<Message, MessageForReadDto>();
            CreateMap<MessageForCreateDto, Message>();
            CreateMap<MessageForUpdateDto, Message>();
        }
    }
}
