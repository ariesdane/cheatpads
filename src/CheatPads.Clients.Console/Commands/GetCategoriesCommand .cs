using IdentityModel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Clients.Console.Commands
{
    using CheatPads.Clients.Console.Services;

    public class GetCategoriesCommand : ICommand
    {
        public string Title { get; set; } = "Get Api Product Categories";

        public string[] Arguments { get; set; }

        public void Execute(string[] args)
        {
            try
            {
                var categories = ApiService.GetCategories();

                categories.ToString().ColoredWriteLine(ConsoleColor.Gray);
            }
            catch(Exception ex)
            {
                ex.InnerException.Message.ConsoleRed();
            }
           
        }

    }
}
