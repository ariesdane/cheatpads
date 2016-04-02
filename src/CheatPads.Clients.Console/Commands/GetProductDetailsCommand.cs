using IdentityModel.Extensions;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Clients.Console.Commands
{
    using CheatPads.Clients.Console.Services;

    public class GetProductDetailsCommand : ICommand
    {
        public string Title { get; set; } = "Get Api Product Details";

        public string[] Arguments { get; set; } = new string[] { "Product Sku" };

        public void Execute(string[] args)
        {
            try
            {
                var product = ApiService.GetProduct(args[0]);

                product.ToString().ColoredWriteLine(ConsoleColor.Gray);
            }
            catch(Exception ex)
            {
                ex.InnerException.Message.ConsoleRed();
            }
           
        }

    }
}
