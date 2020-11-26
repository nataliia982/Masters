using Socio.Business.Models;
using Socio.Controllers.Base;
using System.Threading.Tasks;
using Socio.Business.Managers.Interfaces;
using System.Web.Http;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using System.Net;

namespace Socio.Controllers
{
    [RoutePrefix("api/Message")]
    public class MessageController : CrudController<MessageModel>
    {

        #region Properties



        #endregion

        #region Constructors

        public MessageController(IManagerStore managerStore)
            : base(managerStore, managerStore.MessageManager)
        { }

        #endregion

        #region Actions

        [Authorize]
        [HttpPost]
        [Route("")]
        public override async Task<HttpResponseMessage> CreateAsync([FromBody] MessageModel model)
        {
            model.UserProfileId = User.Identity.GetUserId<int>();
            var id = await ManagerStore.MessageManager.AddAsync(model);
            model.Id = id;
            model.UserProfile = await ManagerStore.UserProfileManager.GetAsync(model.UserProfileId);
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        #endregion

    }
}
