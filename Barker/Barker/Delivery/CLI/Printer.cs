using System;
using System.Collections.Generic;
using Barker.App.Entities;

namespace Barker.Delivery.CLI
{
    public class Printer : IPrinter
    {
        private readonly IConsole _console;

        public Printer(IConsole console)
        {
            _console = console;
        }

        public void PrintBarks(IEnumerable<Bark> barks)
        {
            foreach (var bark in barks)
            {
                _console.WriteLine(bark.Message);
            }
        }
    }
}