using System;

namespace Barker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var commandFactory = new CommandFactory();
            var controller = new Controller(commandFactory);

            string input; 
            do
            {
                input = Console.ReadLine();
                controller.Run(input);
            } while (input != "EXIT");

            Console.Write("Good bye!");
        }
    }
}
