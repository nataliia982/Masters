using Microsoft.AspNet.Identity;
using Socio.BusinessNew.Abstraction;
using Socio.BusinessNew.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Socio.Controllers.api
{
    [RoutePrefix("api/Events")]
    public class EventsController: ApiController
    {
        private readonly IEventsService eventsService;
        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, eventsService.GetEvents());
        }

        [HttpGet]
        [Route(@"ByKey/{id}")]
        public HttpResponseMessage GetEvents([FromUri] string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new List<string>());
        }
    }
}