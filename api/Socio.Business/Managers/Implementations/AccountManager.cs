using Socio.Business.Managers.Base.Implementations;
using Socio.Business.Managers.Base.Interfaces;
using Socio.Business.Models;
using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Socio.Data.Repository.Base.Interfaces;
using Socio.Business.Managers.Interfaces;
using Socio.Business.Infrastructure.Helpers;
using AutoMapper;
using Socio.Data.Exceptions;

namespace Socio.Business.Managers.Implementations
{
    public class AccountManager : CrudManager<UserProfile, UserProfileModel>, IAccountManager
    {

        #region Properties



        #endregion

        #region Constructors

        public AccountManager(
            IApplicationUnitOfWork unitOfWork) 
            : base(unitOfWork, unitOfWork.UserProfiles)
        { }

        #endregion

        #region Interface Members

        public async Task<UserProfileModel> LogIn(string login, string password)
        {
            var model = await UnitOfWork.UserProfiles.GetByLoginAsync(login);
            return
                model != null && PasswordHasher.VerifyMd5Hash(password, model.UserAccount.Password) ?
                Mapper.Map<UserProfileModel>(model) :
                default(UserProfileModel);
        }

        public async Task<UserProfileModel> SignUp(UserProfileModel model)
        {

            if ((await UnitOfWork.UserProfiles.GetByLoginAsync(model.UserAccount.Login)) != null)
            {
                throw new LoginAlreadyExists();
            }

            if((await UnitOfWork.UserProfiles.GetByEmailAsync(model.UserAccount.Email))!=null)
            {
                throw new EmailAlreadyExistsException();
            }

            var accountModel = Mapper.Map<UserAccount>(model.UserAccount);
            accountModel.Password = PasswordHasher.GetMd5Hash(model.UserAccount.Password);

            await UnitOfWork.UserAccounts.AddAsync(accountModel);

            await UnitOfWork.SaveChanges();

            model.UserAccountId = accountModel.Id;

            var profileModel = Mapper.Map<UserProfile>(model);
            profileModel.Role = RoleEnum.User;
            await UnitOfWork.UserProfiles.AddAsync(profileModel);

            await UnitOfWork.SaveChanges();

            profileModel.UserAccount = accountModel;

            return Mapper.Map<UserProfileModel>(profileModel);
        }

        #endregion

        #region Override methods

        public override Task<int> AddAsync(UserProfileModel model)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<List<UserProfileModel>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<UserProfileModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(UserProfileModel model)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
