using AutoMapper;
using Socio.Business.Models;
using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Business.MapperProfiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageModel>()
                //.ForMember(dst => dst.UserProfile, opt => opt.Ignore())
                .ForMember(dst => dst.Conversation, opt => opt.Ignore());

            CreateMap<MessageModel, Message>()
                .ForMember(dst => dst.UserProfile, opt => opt.Ignore())
                .ForMember(dst => dst.Conversation, opt => opt.Ignore());
        }
    }
}
