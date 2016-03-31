using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Clients.Console
{
    public static class Settings
    {
        private const string _ApiBaseUrl = "https://localhost:44390/api";
        private const string _AuthBaseUrl = "https://localhost:44345/connect";

        // client crenditials
        public const string ClientId = "CheatPads.Clients.Console";
        public const string ClientSecret = "D7014A72BB75E3C";
        public const string ClientScope = "CheatPads.Api";
      
        // identity server endpoints
        public const string AuthorizeEndpoint = _AuthBaseUrl + "/authorize";
        public const string LogoutEndpoint = _AuthBaseUrl + "/endsession";
        public const string TokenEndpoint = _AuthBaseUrl + "/token";
        public const string TokenRevocationEndpoint = _AuthBaseUrl + "/revocation";
        public const string UserInfoEndpoint = _AuthBaseUrl + "/userinfo";
        public const string IdentityTokenValidationEndpoint = _AuthBaseUrl + "/identitytokenvalidation";
        public const string IntrospectionEndpoint = _AuthBaseUrl + "/introspect";

        //api endpoints
        public const string ColorsEndpoint = _ApiBaseUrl + "/colors";
        public const string CategoriesEndpoint = _ApiBaseUrl + "/categories";
        public const string ProductsEndpoint = _ApiBaseUrl + "/products";
        public const string UsersEndpoint = _ApiBaseUrl + "/users";
    }
}
