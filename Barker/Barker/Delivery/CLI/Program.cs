using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Barker.Delivery.CLI
{
    public class Program
    {
        public static IController Controller;
        public static IConsole Console;

        static Program()
        {
            var container = CreateIocContainer();
            Controller = container.Resolve<IController>();
            Console = container.Resolve<IConsole>();
        }

        private static WindsorContainer CreateIocContainer()
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());
            return container;
        }

        public static void Main(string[] args)
        {
            string userInput; 
            do
            {
                userInput = Console.ReadLine();
                Controller.Run(userInput);
            } while (userInput != "EXIT");

            Console.WriteLine("Good bye!");
        }
    }
}
