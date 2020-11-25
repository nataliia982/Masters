using Microsoft.AspNet.Identity;
using Socio.BusinessNew.Abstraction;
using Socio.BusinessNew.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Socio.Controllers.api
{
    [RoutePrefix("api/ProfileNew")]
    public class NewProfileController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly IProfileService _profileService;

        public NewProfileController(IAccountService accountService, IProfileService profileService)
        {
            _accountService = accountService;
            _profileService = profileService;
        }

        // Sign up
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Create([FromBody] UserRegisterViewModel model)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _accountService.SignUp(model));
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Update([FromBody] UserProfileViewModel model)
        {
            _profileService.UpdateUser(model);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route(@"IsBanned/{login}")]
        public HttpResponseMessage IsBaned([FromUri]string login)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _profileService.IsBanned(login));
        }

        [HttpGet]
        [Route(@"ByLogin/{login}")]
        public HttpResponseMessage GetByLogin([FromUri]string login)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _profileService.GetByLogin(login));
        }

        [Authorize]
        [HttpGet]
        [Route(@"EditPassword/{newPassword}")]
        public HttpResponseMessage EditPassword([FromUri]string newPassword)
        {
            var id = User.Identity.GetUserId<int>();
            _profileService.EditPassword(newPassword, id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _profileService.GetAllUsers());
        }
        
        [HttpGet]
        [Route(@"BanUser/{id}")]
        public HttpResponseMessage BanUserAsync([FromUri]int id)
        {
            _profileService.BanUser(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}