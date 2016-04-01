using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CheatPads.Api
{
    public class RequiredScopesMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEnumerable<string> _requiredScopes;

        public RequiredScopesMiddleware(RequestDelegate next, List<string> requiredScopes)
        {
            _next = next;
            _requiredScopes = requiredScopes;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                if (!ScopePresent(context.User))
                {
                    context.Response.OnCompleted(Send403, context);
                    return;
                }
                else
                {
                    var roles = context.User.Claims.Where(x => x.Type == "role")?.Select(x => x.Value);
                    var userName = context.User.Claims.FirstOrDefault(x => x.Type == "name")?.Value;
                    var clientId = context.User.Claims.FirstOrDefault(x => x.Type == "client_id")?.Value;

                    var identity = new System.Security.Principal.GenericIdentity(userName ?? clientId);

                    context.User = new System.Security.Principal.GenericPrincipal(identity, roles.ToArray());
                }
            }

            await _next(context);
        }
                
        private bool ScopePresent(ClaimsPrincipal principal)
        {
            foreach (var scope in principal.FindAll("scope"))
            {
                if (_requiredScopes.Contains(scope.Value))
                {
                    return true;
                }
            }

            return false;
        }

        private Task Send403(object contextObject)
        {
            var context = contextObject as HttpContext;
            context.Response.StatusCode = 403;

            return Task.FromResult(0);
        }
    }
}