using IdentityModel.Extensions;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Clients.Console.Commands
{
    using CheatPads.Clients.Console.Services;

    public class GetUsersCommand : ICommand
    {
        public string Title { get; set; } = "Get All User Data";

        public string[] Arguments { get; set; }

        public void Execute(string[] args)
        {
            try
            {
                var data = ApiService.GetUsers();

                data.ToString().ColoredWriteLine(ConsoleColor.Gray);
            }
            catch(Exception ex)
            {
                ex.InnerException.Message.ConsoleRed();
            }
           
        }

    }
}
