using Microsoft.AspNet.Identity;
using Socio.BusinessNew.Abstraction;
using Socio.BusinessNew.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Socio.Controllers.api
{
    [Authorize]
    [RoutePrefix("api/MessageNew")]
    public class NewMessageController : ApiController
    {
        private readonly IMessageService _messageService;

        public NewMessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Create([FromBody] NewMessageViewModel model)
        {
            var userId = User.Identity.GetUserId<int>();
            return Request.CreateResponse(HttpStatusCode.OK, _messageService.PostMessage(model, userId));
        }
    }
}