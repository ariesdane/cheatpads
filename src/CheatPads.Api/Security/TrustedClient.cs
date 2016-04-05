using System;
using System.Linq;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.OptionsModel;

namespace CheatPads.Api.Security
{
    using CheatPads.Framework.Extensions;

     public class TrustedWebClientHandler : AuthorizationHandler<TrustedWebClientRequirement>
     {

        private SecurityConfig _config;

        public TrustedWebClientHandler(IOptions<SecurityConfig> config)
        {
            _config = config.Value;
        }

        protected override void Handle(AuthorizationContext context, TrustedWebClientRequirement requirement)
        {
            var resourceContext = context.Resource as Microsoft.AspNet.Mvc.Filters.AuthorizationContext;

            if (requirement.Validate(resourceContext.HttpContext, _config))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }

    public class TrustedWebClientRequirement : IAuthorizationRequirement {

        public bool Validate(HttpContext context, SecurityConfig config)
        {
            var referer = context.Request.Headers["referer"].ToString();

            if (!String.IsNullOrEmpty(referer))
            {
                var client = new Uri(referer);
                referer = client.IsDefaultPort ? client.Host : client.Host + ":" + client.Port;
            }

            return config.TrustedClients.Contains(referer) 
                || context.User.FindAll("scope").ToList().Any(x => config.RequiredScopes.Contains(x.Value));
        }
    }
}
