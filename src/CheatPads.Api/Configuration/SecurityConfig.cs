using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Api.Configuration
{
    public class SecurityConfig
    {
        public string Authority { get; set; }

        public string Audience { get; set; }

        public string ResourceScope { get; set; }

        public string[] TrustedClients { get; set; }
    }
}
