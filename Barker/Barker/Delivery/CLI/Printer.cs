using System;
using System.Collections.Generic;
using Barker.App.Entities;

namespace Barker.Delivery.CLI
{
    public class Printer : IPrinter
    {
        public void PrintBarks(IEnumerable<Bark> barks)
        {
            foreach (var bark in barks)
            {
                Console.WriteLine(bark.Message);
            }
        }
    }
}