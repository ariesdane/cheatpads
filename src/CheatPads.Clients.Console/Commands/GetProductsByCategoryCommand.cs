using IdentityModel.Extensions;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Clients.Console.Commands
{
    using CheatPads.Clients.Console.Services;

    public class GetProductsByCategoryCommand : ICommand
    {
        public string Title { get; set; } = "Get Api Products By Category";

        public string[] Arguments { get; set; } = new string[] { "Category Name" };

        public void Execute(string[] args)
        {
            try
            {
                var products = ApiService.GetProductsByCategory(args[0]);

                products.ToString().ColoredWriteLine(ConsoleColor.Gray);
            }
            catch(Exception ex)
            {
                ex.InnerException.Message.ConsoleRed();
            }
           
        }

    }
}
