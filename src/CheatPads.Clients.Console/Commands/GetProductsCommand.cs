using IdentityModel.Extensions;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Clients.Console.Commands
{
    using CheatPads.Clients.Console.Services;

    public class GetProductsCommand : ICommand
    {
        public string Title { get; set; } = "Get Api Product Data";

        public string[] Arguments { get; set; }

        public void Execute(string[] args)
        {
            try
            {
                var products = ApiService.GetProducts();

                products.ToString().ColoredWriteLine(ConsoleColor.Gray);
            }
            catch(Exception ex)
            {
                ex.InnerException.Message.ConsoleRed();
            }
           
        }

    }
}
