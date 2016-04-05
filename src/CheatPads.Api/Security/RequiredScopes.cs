using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CheatPads.Api
{
    using CheatPads.Api.Security;

    public class RequiredScopesMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEnumerable<string> _requiredScopes;
        private readonly IEnumerable<string> _trustedClients;
        private readonly string _authType;

        public RequiredScopesMiddleware(RequestDelegate next, SecurityConfig config)
        {
            _next = next;

            _authType = config.AuthenticationType;
            _requiredScopes = config.RequiredScopes;
            _trustedClients = config.TrustedClients;
            
        }

        public async Task Invoke(HttpContext context)
        {

            if (!(IsScopePresent(context.User) || IsTrustedClient(context)))
            {
                context.Response.OnCompleted(Send403, context);
                return;
            }
            else if(context.User.Identity.IsAuthenticated)
            {
                context.User = CreateClaimsPrinciple(context.User);
            }

            await _next(context);
        }
                
        private bool IsScopePresent(ClaimsPrincipal principal)
        {
            foreach (var scope in principal?.FindAll("scope"))
            {
                if (_requiredScopes.Contains(scope.Value))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsTrustedClient(HttpContext context)
        {
            var referer = context.Request.Headers["referer"].ToString();

            if (!String.IsNullOrEmpty(referer))
            {
                var client = new Uri(referer);
                referer = client.IsDefaultPort ? client.Host : client.Host + ":" + client.Port;
            }

            return _trustedClients.Contains(referer);
        }

        private Task Send403(object contextObject)
        {
            var context = contextObject as HttpContext;
            context.Response.StatusCode = 403;

            return Task.FromResult(0);
        }

        private ClaimsPrincipal CreateClaimsPrinciple(ClaimsPrincipal principal)
        {
            ClaimsIdentity identity;

            if(principal.Claims.Any(x => x.Type == "sub"))
            {
                // identity of the subject (user)
                identity = new ClaimsIdentity(principal.Claims, _authType, "name", "role");
            }
            else
            {
                // identity of the client
                identity = new ClaimsIdentity(principal.Claims, _authType, "client_id", "client_role");
            }

            return new ClaimsPrincipal(identity);
        }
    }
}