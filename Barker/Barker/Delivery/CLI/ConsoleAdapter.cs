using System;

namespace Barker.Delivery.CLI
{
    public class ConsoleAdapter : IConsole
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}