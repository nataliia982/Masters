using AutoMapper;
using Socio.Business.Models;
using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Business.MapperProfiles
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            CreateMap<UserProfile, UserProfileModel>();

            CreateMap<UserProfileModel, UserProfile>()
                .ForMember(dst => dst.UserAccount, opt => opt.Ignore());
        }
    }
}
