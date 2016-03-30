using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Clients.Console.Commands
{
    public interface ICommand
    {
        string Title { get; set; }

        string[] Arguments { get; set; }

        void Execute(params string[] args);
    }
}
