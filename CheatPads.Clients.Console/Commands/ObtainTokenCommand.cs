using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Extensions;
using CheatPads.Clients.Console.Services;

namespace CheatPads.Clients.Console.Commands
{
    public class ObtainTokenCommand : ICommand
    {
        public string Title { get; set; } = "Obtain Access Token";

        public string[] Arguments { get; set; }

        public void Execute(string[] args)
        {
            TokenService.ObtainToken();
            TokenService.PrintTokenData();
        }
    }
}
