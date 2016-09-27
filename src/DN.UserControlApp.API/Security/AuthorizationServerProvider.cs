﻿using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace DN.UserControlApp.API.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
       
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //var anunciante = _anuncianteAppService.Autenticar(context.UserName, context.Password);

            //if (anunciante == null)
            //{
            //    context.SetError("invalid_grant", "E-mail ou senha incorretos");
            //    return;
            //}

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            //identity.AddClaim(new Claim(ClaimTypes.Name, anunciante.Email));
            //identity.AddClaim(new Claim(ClaimTypes.GivenName, anunciante.Nome));

            GenericPrincipal principal = new GenericPrincipal(identity, null);
            Thread.CurrentPrincipal = principal;

            context.Validated(identity);

        }
    }
}