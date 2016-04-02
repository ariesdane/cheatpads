using System;
using System.Collections.Generic;
using System.Linq;
using IdentityModel.Extensions;

using System.Runtime;
using System.Threading.Tasks;

namespace CheatPads.Clients.Console.Commands
{
    public static class CommandManager
    {
        private static List<ICommand> _commands = new List<ICommand>();

        public static void RegisterCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public static void ShowCommandMenu()
        {
            ICommand command;
            string[] arguments = new string[] { };

            NewScreen("Available Commands");
            command = PromptForCommand();

            NewScreen("Commands\\" + command.Title);

            if (command.Arguments != null)
            {
                NewSection("Arguments");
                arguments = PromptForCommandArguments(command);
            }

            NewSection("Results");
            command.Execute(arguments);

            System.Console.WriteLine();
            "Press any key to continue...".ConsoleYellow();
            System.Console.ReadLine();

            ShowCommandMenu();
        }

        private static ICommand PromptForCommand()
        {
            int index = -1;

            for (var i = 0; i < _commands.Count; i++)
            {
                String.Format("{0}). {1}", i + 1, _commands[i].Title).ConsoleYellow();
            }
            System.Console.WriteLine();

            while (true) {
                System.Console.Write("Enter Option # >> ");

                var option = System.Console.ReadLine();
                if (int.TryParse(option, out index) && index >= 1 && index <= _commands.Count)
                {
                    break;
                }
                else
                {
                    "Invalid Option!\n".ConsoleRed();
                }
            }
            System.Console.WriteLine();

            return _commands[index-1];
        }

        private static string[] PromptForCommandArguments(ICommand command)
        {          
            var args = new List<string>();

            if (command.Arguments != null && command.Arguments.Length > 0) {
                foreach (var prompt in command.Arguments)
                {
                    System.Console.Write(prompt + " >> ");
                    
                    var input = System.Console.ReadLine();
                    args.Add(input);
                }
            }
            System.Console.WriteLine();

            return args.ToArray();
        }

        private static void NewScreen(string title)
        {
            System.Console.Clear();
            "-------------------------------------------------".ConsoleGreen();
            title.ToUpper().ConsoleYellow();
            "-------------------------------------------------\n".ConsoleGreen();
        }

        private static void NewSection(string title)
        {
            String.Format("[{0}]\n", title.ToUpper()).ConsoleYellow();
        }
    }
}
