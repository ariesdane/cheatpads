using IdentityModel.Extensions;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Clients.Console.Commands
{
    using CheatPads.Clients.Console.Services;

    public class GetUserPrincipleCommand : ICommand
    {
        public string Title { get; set; } = "Get Api User Principle";

        public string[] Arguments { get; set; }

        public void Execute(string[] args)
        {
            try
            {
                var principle = ApiService.GetUserPrinciple();

                principle.ToString().ColoredWriteLine(ConsoleColor.Gray);
            }
            catch(Exception ex)
            {
                ex.InnerException.Message.ConsoleRed();
            }
           
        }

    }
}
