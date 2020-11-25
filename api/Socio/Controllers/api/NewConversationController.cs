using Microsoft.AspNet.Identity;
using Socio.BusinessNew.Abstraction;
using Socio.BusinessNew.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Socio.Controllers.api
{
    [RoutePrefix("api/ConversationNew")]
    public class NewConversationController : ApiController
    {
        private readonly IConversationService _conversationService;

        public NewConversationController(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        [HttpGet]
        [Route(@"ByUser/{id:int:min(1)}")]
        public HttpResponseMessage GetByConversationId([FromUri] int id)
        {
            var userId = User.Identity.GetUserId<int>();
            return Request.CreateResponse(HttpStatusCode.OK, _conversationService.GetConversation(userId, id));
        }

        [HttpGet]
        [Route(@"LatestByUser")]
        public HttpResponseMessage GetByUser()
        {
            var userId = User.Identity.GetUserId<int>();
            return Request.CreateResponse(HttpStatusCode.OK, _conversationService.GetConversations(userId));
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage GetUsers([FromBody]List<NewConversation> convs)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _conversationService.GetUsers(convs));
        }
    }
}