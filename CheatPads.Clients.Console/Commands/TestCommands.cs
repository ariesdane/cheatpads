using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Extensions;

namespace CheatPads.Clients.Console.Commands
{
    public class StandardGreetingCommand : ICommand
    {
        public string[] Arguments { get; set; } = new string[] { "Your Name" };

        public string Title { get; set; } = "Standard Greeting";

        public void Execute(string[] args)
        {
            String.Format("Hello there, {0}!", args[0]).ColoredWriteLine(ConsoleColor.Gray);
        }
    }

    public class AdvancedGreetingCommand : ICommand
    {
        public string[] Arguments { get; set; } = new string[] { "Your Name", "Your Age"};

        public string Title { get; set; } = "Advanced Greeting";

        public void Execute(string[] args)
        {
            String.Format("Hello there, {0}! Your age is {1}. Wow.", args[0], args[1]).ColoredWriteLine(ConsoleColor.Gray);
        }
    }
}
