using Socio.Business.Managers.Interfaces;
using Socio.Business.Models;
using Socio.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Socio.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : CrudController<UserAccountModel>
    {
        #region Properties



        #endregion

        #region Constructors

        public AccountController(IManagerStore managerStore)
            : base(managerStore, managerStore.UserAccountManager)
        { }

        #endregion

        #region Actions



        #endregion
        
    }
}
