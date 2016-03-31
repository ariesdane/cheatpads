using IdentityModel.Extensions;
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CheatPads.Clients.Console.Commands
{
    using CheatPads.Clients.Console.Services;

    public class ShowSettingsCommand : ICommand
    {
        public string Title { get; set; } = "Show Application Settings";

        public string[] Arguments { get; set; }

        public void Execute(string[] args)
        {
            var typeData = typeof(Settings).GetFields().ToDictionary(x => x.Name, x => x.GetValue(null));
            var itor = typeData.GetEnumerator();

            while(itor.MoveNext()){
                System.Console.WriteLine(itor.Current.Key);
                String.Format("--> {0}", itor.Current.Value).ColoredWriteLine(ConsoleColor.Gray);
                System.Console.WriteLine();
            }
        }
    }
}
