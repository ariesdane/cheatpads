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
            CommandManager.RegisterCommand(new ShowGreetingCommand());
            CommandManager.RegisterCommand(new ShowSettingsCommand());
            CommandManager.RegisterCommand(new ObtainClientTokenCommand());
            CommandManager.RegisterCommand(new ObtainUserTokenCommand());
            CommandManager.RegisterCommand(new PrintTokenDataCommand());
            CommandManager.RegisterCommand(new GetUserPrincipleCommand());
            CommandManager.RegisterCommand(new GetUsersCommand());
            CommandManager.RegisterCommand(new GetProductsCommand());
            CommandManager.RegisterCommand(new GetProductDetailsCommand());
            CommandManager.RegisterCommand(new GetProductsByCategoryCommand());
            CommandManager.RegisterCommand(new GetCategoriesCommand());
            CommandManager.RegisterCommand(new GetColorsCommand());         
            CommandManager.RegisterCommand(new ExitAppCommand());
            CommandManager.ShowCommandMenu();
        }
    }
}
