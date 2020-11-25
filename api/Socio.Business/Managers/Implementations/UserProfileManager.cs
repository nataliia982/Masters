using Socio.Business.Managers.Interfaces;
using Socio.Business.Models;
using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Socio.Data.Repository.Base.Interfaces;
using AutoMapper;
using Socio.Business.Managers.Base.Implementations;

namespace Socio.Business.Managers.Implementations
{
    public class UserProfileManager : CrudManager<UserProfile, UserProfileModel>, IUserProfileManager
    {

        #region Properties



        #endregion

        #region Constructors

        public UserProfileManager(IApplicationUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.UserProfiles)
        { }

        #endregion

        #region Interface Members

        public async Task<UserProfileModel> GetByLoginAsync(string login)
        {
            return Mapper.Map<UserProfileModel>(
                await UnitOfWork.UserProfiles.GetByLoginAsync(login));
        }

        public async Task<UserAccountModel> IsBannedAsync(string login)
        {
            var users = await UnitOfWork.UserAccounts.GetAsync();
            return Mapper.Map<UserAccountModel>(users.FirstOrDefault(x => x.Login == login));
        }

        public async Task BanUserAsync(UserAccountModel userModel)
        {
            var user = Mapper.Map<UserAccount>(userModel);
            user.IsBanned = !user.IsBanned;

            await UnitOfWork.UserAccounts.UpdateAsync(user);
            await UnitOfWork.SaveChanges();
        }

        #endregion

    }
}
