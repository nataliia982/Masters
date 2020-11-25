using Socio.Business.Models;
using Socio.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Socio.Business.Managers.Base.Interfaces;
using Socio.Business.Managers.Interfaces;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using Microsoft.AspNet.Identity;

namespace Socio.Controllers
{
    [RoutePrefix("api/Conversation")]
    public class ConversationController : CrudController<ConversationModel>
    {

        #region Properties



        #endregion

        #region Constructors

        public ConversationController(IManagerStore managerStore)
            : base(managerStore, managerStore.ConversationManager)
        { }

        #endregion

        #region Actions

        [Authorize]
        [HttpGet]
        [Route(@"ByUser/{id:int:min(1)}")]
        public async Task<HttpResponseMessage> GetByUsersIdsAsync([FromUri] int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                await ManagerStore.ConversationManager.GetByUsersIdsAsync(User.Identity.GetUserId<int>() ,id));
        }

        [Authorize]
        [HttpGet]
        [Route(@"LatestByUser")]
        public async Task<HttpResponseMessage> GetByUserIdAsync()
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                await ManagerStore.ConversationManager.GetByUserIdAsync(User.Identity.GetUserId<int>()));
        }

        #endregion

    }
}
