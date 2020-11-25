using Socio.Business.Managers.Base.Interfaces;
using Socio.Business.Models;
using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Business.Managers.Interfaces
{
    public interface IUserProfileManager : ICrudManager<UserProfileModel>
    {
        Task<UserProfileModel> GetByLoginAsync(string login);
        Task<UserAccountModel> IsBannedAsync(string login);
        Task BanUserAsync(UserAccountModel userAccount);
    }
}
