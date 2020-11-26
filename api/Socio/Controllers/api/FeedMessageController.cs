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
    [Authorize]
    [RoutePrefix("api/FeedMessage")]
    public class FeedMessageController : CrudController<FeedMessageModel>
    {

        #region Properties



        #endregion

        #region Constructors

        public FeedMessageController(IManagerStore managerStore)
            : base(managerStore, managerStore.FeedMessageManager)
        { }

        #endregion

        #region Actions

        [HttpPost]
        [Route("")]
        public override async Task<HttpResponseMessage> CreateAsync([FromBody] FeedMessageModel model)
        {
            model.FromUserProfileId = User.Identity.GetUserId<int>();
            var id = await ManagerStore.FeedMessageManager.AddAsync(model);
            model.Id = id;
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [HttpPut]
        [Route("")]
        public override Task<HttpResponseMessage> UpdateAsync([FromBody]FeedMessageModel model)
        {
            model.WasEdited = true;
            return base.UpdateAsync(model);
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        public override Task<HttpResponseMessage> DeleteAsync([FromUri]int id)
        {
            return base.DeleteAsync(id);
        }

        [HttpGet]
        [Route(@"ByUser/{id:int:min(1)}")]
        public async Task<HttpResponseMessage> GetByUsersIdsAsync([FromUri] int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                await ManagerStore.FeedMessageManager.GetAllFeedForUser(id));
        }

        #endregion

    }
}
