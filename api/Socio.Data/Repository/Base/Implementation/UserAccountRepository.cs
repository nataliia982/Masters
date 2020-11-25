using Socio.Data.Entities;
using Socio.Data.Repository.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Data.Repository.Base.Implementation
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {

        #region Properties



        #endregion

        #region Constructors

        public UserAccountRepository(DataContext context)
                    : base(context)
        { }

        #endregion

        #region Interface Members

        public override async Task<UserAccount> GetAsync(int id)
        {
            UserAccount ua = new UserAccount() { Id = 1, Email = "user@email.com", Login = "test", Password = "111" };

            return await Task.FromResult(ua);
        }

        #endregion

    }
}
