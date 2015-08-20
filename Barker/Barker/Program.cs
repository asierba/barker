using System;

namespace Barker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input; 
            do
            {
                input = Console.ReadLine();
            } while (input != "EXIT");

            Console.Write("Good bye!");
        }
    }
}
