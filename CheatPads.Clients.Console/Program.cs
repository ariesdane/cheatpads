using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

using CheatPads.Clients.Console.Commands;

namespace CheatPads.Clients.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CommandManager.RegisterCommand(new StandardGreetingCommand());
            CommandManager.RegisterCommand(new AdvancedGreetingCommand());
            CommandManager.RegisterCommand(new ObtainTokenCommand());
            CommandManager.RegisterCommand(new PrintTokenDataCommand());
            CommandManager.RegisterCommand(new ExitAppCommand());

            CommandManager.ShowCommandMenu();
        }
    }
}
