using IdentityModel.Extensions;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Clients.Console.Commands
{
    using CheatPads.Clients.Console.Services;

    public class GetColorDetailsCommand : ICommand
    {
        public string Title { get; set; } = "Get Api Color Details";

        public string[] Arguments { get; set; } = new string[] { "Color Id" };

        public void Execute(string[] args)
        {
            try
            {
                ApiService.GetColor(args[0]).ToString().ColoredWriteLine(ConsoleColor.Gray);
            }
            catch(Exception ex)
            {
                ex.InnerException.Message.ConsoleRed();
            }
           
        }

    }
}
