using System;
using Microsoft.AspNet.Authorization;
using System.Security.Claims;

namespace CheatPads.Api
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeRouteParam : AuthorizeAttribute
    {
        private string _claimType;
        private string _paramName;
        private bool _isAuthorized = false;

        /// <summary>
        /// Performs a claims authorization check for the claim type specified based the 
        /// current value of a route parameter to inspect.
        /// </summary>
        /// <param name="claimType">Claim type to authorize</param>
        /// <param name="paramName">Parameter name to inspect</param>
        /// <remarks>[AriesDane] 2015-02-13</remarks>
        public AuthorizeRouteParam(string claimType, string parameterName) : base() {                   
            if (claimType == null) {
                throw new ArgumentNullException("claimType");
            }

            if (parameterName == null) {
                throw new ArgumentNullException("parameterName");
            }
            _claimType = claimType;
            _paramName = parameterName;
        }

        /*
        protected override bool IsAuthorized(HttpActionContext context) {
            return _isAuthorized;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null || actionContext.RequestContext == null){
                throw new HttpRequestException("The request context could not be established.");
            }

            var principal = actionContext.RequestContext.Principal;
            var routeData = actionContext.Request.GetRouteData();  

            if (principal == null || principal.Identity == null) {
                throw new UnauthorizedAccessException("Anonymous access to this resource is restricted.");
            }

            if (routeData.Values == null || !routeData.Values.ContainsKey(_paramName) || routeData.Values[_paramName] == null) {
                throw new UnauthorizedAccessException("Access to this resource could not be granted. The request contained an invalid or missing claims identifier.");
            }

            var claimsIdentity = principal.Identity as ClaimsIdentity;
            var claimValue = (string)routeData.Values[_paramName];
               
            if(claimsIdentity.HasClaim(_claimType, claimValue)){
                _isAuthorized = true;
            }
            else {
                throw new UnauthorizedAccessException("Access to this resource could not be granted. The current user does not have the required security claim.");  
            }
               
        }
        */
    }

}
