using System.Collections.Generic;
using Barker.App.Entities;
using Barker.External;
using Castle.Core.Internal;

namespace Barker.Delivery.CLI
{
    public class BarksPrinter : IBarksPrinter
    {
        private readonly IConsole _console;
        private readonly IClock _clock;

        public BarksPrinter(IConsole console, IClock clock)
        {
            _console = console;
            _clock = clock;
        }

        public void PrintBarks(IEnumerable<Bark> barks)
        {
            barks.ForEach(x => _console.WriteLine($"{x.Message}({_clock.GetTimePassedFrom(x.CreatedDate)} ago)"));
        }

        public void PrintBarks(IEnumerable<Bark> barks, string username)
        {
            barks.ForEach(x => _console.WriteLine($"{username} - {x.Message}({_clock.GetTimePassedFrom(x.CreatedDate)} ago)"));
        }
    }
}