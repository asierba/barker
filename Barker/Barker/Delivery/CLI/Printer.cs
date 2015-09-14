using System.Collections.Generic;
using Barker.App.Entities;

namespace Barker.Delivery.CLI
{
    public class Printer : IPrinter
    {
        private readonly IConsole _console;
        private readonly IClock _clock;

        public Printer(IConsole console, IClock clock)
        {
            _console = console;
            _clock = clock;
        }

        public void PrintBarks(IEnumerable<Bark> barks)
        {
            foreach (var bark in barks)
            {
                _console.WriteLine($"{bark.Message}({_clock.GetTimeSpanned(bark.Date)} ago)");
            }
        }

        public void PrintBarksWithUsername(IEnumerable<Bark> barks)
        {
            foreach (var bark in barks)
            {
                _console.WriteLine($"{bark.Username} - {bark.Message}({_clock.GetTimeSpanned(bark.Date)} ago)");
            }
        }
    }
}