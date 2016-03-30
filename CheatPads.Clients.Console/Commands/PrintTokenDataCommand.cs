using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Extensions;
using CheatPads.Clients.Console.Services;

namespace CheatPads.Clients.Console.Commands
{
    public class PrintTokenDataCommand : ICommand
    {
        public string Title { get; set; } = "Print Token Data";

        public string[] Arguments { get; set; }

        public void Execute(string[] args)
        {
            TokenService.PrintTokenData();
        }
    }
}
