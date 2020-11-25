using Socio.Business.Managers.Base.Interfaces;
using Socio.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Business.Managers.Interfaces
{
    public interface IAccountManager : ICrudManager<UserProfileModel>
    {
        Task<UserProfileModel> LogIn(string login, string password);
        Task<UserProfileModel> SignUp(UserProfileModel model);
    }
}
