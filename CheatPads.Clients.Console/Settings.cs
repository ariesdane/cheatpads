using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Clients.Console
{
    public static class Settings
    {
        public const string ClientId = "CheatPads.Clients.Console";
        public const string ClientSecret = "D7014A72BB75E3C";
        public const string ClientScope = "CheatPads.Api";

        public const string BaseAddress = "https://localhost:44345";

        public const string AuthorizeEndpoint = BaseAddress + "/connect/authorize";
        public const string LogoutEndpoint = BaseAddress + "/connect/endsession";
        public const string TokenEndpoint = BaseAddress + "/connect/token";
        public const string TokenRevocationEndpoint = BaseAddress + "/connect/revocation";
        public const string UserInfoEndpoint = BaseAddress + "/connect/userinfo";
        public const string IdentityTokenValidationEndpoint = BaseAddress + "/connect/identitytokenvalidation";
        public const string IntrospectionEndpoint = BaseAddress + "/connect/introspect";
    }
}
