using AutoMapper;
using Socio.Business.Models;
using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Business.MapperProfiles
{
    public class ConversationProfile : Profile
    {
        public ConversationProfile()
        {
            CreateMap<Conversation, ConversationModel>();

            CreateMap<ConversationModel, Conversation>()
                .ForMember(dst => dst.UserProfiles, opt => opt.Ignore())
                .ForMember(dst => dst.Messages, opt => opt.Ignore());
        }
    }
}
