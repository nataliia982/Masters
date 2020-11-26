using AutoMapper;
using Socio.Business.Models;
using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Business.MapperProfiles
{
    public class UserAccountProfile : Profile
    {
        public UserAccountProfile()
        {
            CreateMap<UserAccount, UserAccountModel>()
                .ForMember(dst => dst.Password, opt => opt.Ignore());

            CreateMap<UserAccountModel, UserAccount>();
        }
    }
}
