using AutoMapper;
using Socio.Business.Models;
using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.Business.MapperProfiles
{
    public class FeedMessageProfile : Profile
    {
        public FeedMessageProfile()
        {
            CreateMap<FeedMessage, FeedMessageModel>();

            CreateMap<FeedMessageModel, FeedMessage>()
                .ForMember(dst => dst.FromUserProfile, opt => opt.Ignore())
                .ForMember(dst => dst.ToUserProfile, opt => opt.Ignore());
        }
    }
}
