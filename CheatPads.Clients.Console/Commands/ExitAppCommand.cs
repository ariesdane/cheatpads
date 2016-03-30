using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Clients.Console.Commands
{
    public class ExitAppCommand : ICommand
    {
        public string Title { get; set; } = "Exit Application";

        public string[] Arguments { get; set; }

        public void Execute(string[] args)
        {
            Environment.Exit(0);
        }
    }
}
