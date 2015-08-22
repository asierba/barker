using System;
using System.Collections.Generic;

namespace Barker
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