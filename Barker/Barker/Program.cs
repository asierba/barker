using System;

namespace Barker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBarkRepository barkRepository = new BarkRepository();
            IPrinter printer = new Printer();
            var commandFactory = new CommandFactory(barkRepository, printer);
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
