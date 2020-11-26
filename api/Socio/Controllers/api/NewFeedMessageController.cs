using Microsoft.AspNet.Identity;
using Socio.BusinessNew.Abstraction;
using Socio.BusinessNew.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Socio.Controllers.api
{
    [Authorize]
    [RoutePrefix("api/FeedMessageNew")]
    public class NewFeedMessageController : ApiController
    {
        private readonly IFeedService _feedService;

        public NewFeedMessageController(IFeedService feedService)
        {
            _feedService = feedService;
        }

        [HttpGet]
        [Route(@"ByUser/{id:int:min(1)}")]
        public HttpResponseMessage GetByUserId([FromUri] int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _feedService.GetFeeds(id));
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Create([FromBody] FeedMessageViewModel model)
        {
            var id = User.Identity.GetUserId<int>();
            var createdFeed = _feedService.CreateFeed(model, id);
            return Request.CreateResponse(HttpStatusCode.OK, createdFeed);
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Update([FromBody] FeedMessageViewModel model)
        {
            var editedFeed = _feedService.UpdateFeed(model);
            return Request.CreateResponse(HttpStatusCode.OK, editedFeed);
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            _feedService.DeleteFeed(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}