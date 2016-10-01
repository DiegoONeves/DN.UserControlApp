using DN.UserControlApp.Domain.Account.Services;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

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

            var user = _userAppService.GetByEmail(context.UserName);

            if (user == null || !user.Authenticate(context.UserName, context.Password))
            {
                context.SetError("invalid_grant", "E-mail ou senha incorretos");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            GenericPrincipal principal = new GenericPrincipal(identity, null);
            Thread.CurrentPrincipal = principal;

            context.Validated(identity);

        }
    }
}