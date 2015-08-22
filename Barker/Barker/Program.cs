using System;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Barker
{
    public class Program
    {
        private static readonly Controller Controller;

        static Program()
        {
            var container = CreateIocContainer();
            Controller = container.Resolve<Controller>();
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
