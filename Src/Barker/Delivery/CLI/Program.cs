using Castle.Windsor;

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

            while ((userInput = _console.ReadLine()).ToLower() != "exit") 
            {
                 _controller.Run(userInput);
            } 

            _console.WriteLine("Good bye!");
        }
    }
}
