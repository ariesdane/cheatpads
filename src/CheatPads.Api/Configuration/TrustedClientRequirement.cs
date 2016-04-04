using System;
using System.Linq;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.OptionsModel;

namespace CheatPads.Api.Configuration
{

    public class TrustedClientRequirement : AuthorizationHandler<TrustedClientRequirement>, IAuthorizationRequirement
    {
        private IServiceProvider _provider;
        private SecurityConfig _config;
        private string[] _trustedClients;
        private string _resourceScope;

        public TrustedClientRequirement(IServiceProvider serviceProvider)
        {
            _provider = serviceProvider;
            _config = serviceProvider.GetService<IOptions<SecurityConfig>>().Value;
        }

        protected override void Handle(AuthorizationContext context, TrustedClientRequirement requirement)
        {
            var resourceContext = context.Resource as Microsoft.AspNet.Mvc.Filters.AuthorizationContext;
            var referer = resourceContext.HttpContext.Request.Headers["referer"].ToString();

            if (!String.IsNullOrEmpty(referer))
            {
                var client = new Uri(referer);
                referer = client.IsDefaultPort ? client.Host : client.Host + ":" + client.Port;
            }
            
            if (_config.TrustedClients.Contains(referer) || context.User.HasClaim("scope", _config.ResourceScope))
            {
                context.Succeed(requirement);
            }
            else {
                resourceContext.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Fail();
                //throw new UnauthorizedAccessException("This API can only be accessed by trusted clients.");
            }
        }
    }
}
