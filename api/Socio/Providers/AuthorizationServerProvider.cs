using Socio.App_Start;
using Socio.Business.Managers.Interfaces;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Ninject;
using Microsoft.AspNet.Identity;
using Socio.BusinessNew.Abstraction;

namespace Socio.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IAccountManager _manager = NinjectWebCommon.Kernel.Get<IAccountManager>();
        private IAccountService _service = NinjectWebCommon.Kernel.Get<IAccountService>();

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Since we're not implementing clients-based approach - validate all clients.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //old v
            //var user = await _manager.LogIn(context.UserName, context.Password);

            var user = _service.LogIn(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            //old v
            //identity.AddClaim(new Claim(ClaimTypes.Role, user.Role == Data.Entities.RoleEnum.Admin ? "Admin" : "User"));

            identity.AddClaim(new Claim(ClaimTypes.Role, user.Role));

            context.Validated(identity);

        }

        
    }
}