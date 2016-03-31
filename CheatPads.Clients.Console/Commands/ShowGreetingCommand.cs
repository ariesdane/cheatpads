using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Extensions;

namespace CheatPads.Clients.Console.Commands
{
    public class ShowGreetingCommand : ICommand
    {
        public string[] Arguments { get; set; } = new string[] { "Your Name" };

        public string Title { get; set; } = "Show Standard Greeting";

        public void Execute(string[] args)
        {
            String.Format("Hello there, {0}!", args[0]).ColoredWriteLine(ConsoleColor.Gray);
        }
    }
}
