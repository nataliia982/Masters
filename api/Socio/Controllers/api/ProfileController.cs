using Socio.Business.Models;
using Socio.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Socio.Business.Managers.Base.Interfaces;
using Socio.Business.Managers.Interfaces;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Socio.Controllers
{
    [RoutePrefix("api/Profile")]
    public class ProfileController : CrudController<UserProfileModel>
    {

        #region Properties


        #endregion

        #region Constructors

        public ProfileController(IManagerStore managerStore)
            : base(managerStore, managerStore.UserProfileManager)
        { }

        #endregion

        #region Actions

        [HttpGet]
        [Route("")]
        public override async Task<HttpResponseMessage> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet]
        [Route(@"ByLogin/{login}")]
        public async Task<HttpResponseMessage> GetByLoginAsync([FromUri]string login)
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                await base.ManagerStore.UserProfileManager.GetByLoginAsync(login));
        }

        [HttpGet]
        [Route(@"IsBanned/{login}")]
        public async Task<HttpResponseMessage> IsBanedAsync([FromUri]string login)
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                await base.ManagerStore.UserProfileManager.IsBannedAsync(login));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("BanUser")]
        public async Task<HttpResponseMessage> BanUserAsync([FromBody]UserAccountModel userAccount)
        {
            await base.ManagerStore.UserProfileManager.BanUserAsync(userAccount);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("")]
        public override async Task<HttpResponseMessage> CreateAsync([FromBody] UserProfileModel model)
        {
            return Request.CreateResponse(HttpStatusCode.OK, 
                await ManagerStore.AccountManager.SignUp(model));
        }

        //[Authorize]
        [HttpPut]
        [Route("")]
        public override Task<HttpResponseMessage> UpdateAsync([FromBody]UserProfileModel model)
        {
            return base.UpdateAsync(model);
        }

        #endregion

    }
}
