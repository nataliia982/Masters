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
using Socio.Business.Infrastructure.Helpers;

namespace Socio.Business.Managers.Implementations
{
    public class UserAccountManager : CrudManager<UserAccount, UserAccountModel>, IUserAccountManager
    {

        #region Properties



        #endregion

        #region Constructors

        public UserAccountManager(IApplicationUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.UserAccounts)
        { }

        #endregion

        #region Interface Members



        #endregion
        
    }
}
