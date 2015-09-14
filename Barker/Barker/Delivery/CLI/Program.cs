using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Barker.Delivery.CLI
{
    public class Program
    {
        private static IController _controller;
        private static IConsole _console;
        public static WindsorContainer Container;

        static Program()
        {
            Container = CreateIocContainer();
        }

        private static WindsorContainer CreateIocContainer()
        {
            var container = new WindsorContainer();
            container.Install(new IocContainerSetup());
            return container;
        }

        public static void Main(string[] args)
        {
            _controller = Container.Resolve<IController>();
            _console = Container.Resolve<IConsole>();

            string userInput; 
            do
            {
                userInput = _console.ReadLine();
                if(userInput != "EXIT") _controller.Run(userInput);
            } while (userInput != "EXIT");

            _console.WriteLine("Good bye!");
        }
    }
}
