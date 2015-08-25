using System;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Barker.Delivery.CLI
{
    public class Program
    {
        public static IController Controller;

        static Program()
        {
            var container = CreateIocContainer();
            Controller = container.Resolve<IController>();
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

            Console.Write("Good bye!");
        }
    }
}
