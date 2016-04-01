using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Extensions;
using CheatPads.Clients.Console.Services;

namespace CheatPads.Clients.Console.Commands
{
    public class ObtainUserTokenCommand : ICommand
    {
        public string Title { get; set; } = "Obtain User Access Token";

        public string[] Arguments { get; set; } = new string[] { "Username", "Password" };

        public void Execute(string[] args)
        {
            TokenService.ObtainUserToken(args[0], args[1]);
            TokenService.PrintTokenData();
        }
    }
}
