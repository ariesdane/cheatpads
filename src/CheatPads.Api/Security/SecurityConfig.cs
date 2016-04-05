using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Api.Security
{
    public class SecurityConfig
    {
        public string AuthenticationType { get; set; }

        public string Authority { get; set; }

        public string Audience { get; set; }

        public List<string> RequiredScopes { get; set; }

        public List<string> TrustedClients { get; set; }
    }
}
