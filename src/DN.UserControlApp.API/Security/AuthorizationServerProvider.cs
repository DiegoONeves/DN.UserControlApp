using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using DN.UserControlApp.Domain.Account.Services;

namespace DN.UserControlApp.API.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUserApplicationService _userAppService;

        public AuthorizationServerProvider(IUserApplicationService userService)
        {
            _userAppService = userService;
        }


        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var hasUser = _userAppService.Authenticate(context.UserName, context.Password);
            var user = _userAppService.GetByUserName(context.UserName);

            if (!hasUser)
            {
                context.SetError("invalid_grant", "E-mail ou senha incorretos");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            //identity.AddClaim(new Claim(ClaimTypes.GivenName, user.UserName));

            GenericPrincipal principal = new GenericPrincipal(identity, null);
            Thread.CurrentPrincipal = principal;

            context.Validated(identity);

        }
    }
}