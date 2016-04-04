using IdentityModel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Clients.Console.Commands
{
    using CheatPads.Clients.Console.Services;

    public class CreateColorCommand : ICommand
    {
        public string Title { get; set; } = "Create Api Color Data";

        public string[] Arguments { get; set; } = new String[] { "Color Name", "Hex Code" };

        public void Execute(string[] args)
        {
            try
            {
                var result = ApiService.CreateColor(args[0], args[1]);

                result.ToString().ColoredWriteLine(ConsoleColor.Gray);
            }
            catch(Exception ex)
            {
                ex.InnerException.Message.ConsoleRed();
            }
           
        }

    }
}
