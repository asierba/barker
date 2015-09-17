namespace Barker.Delivery.CLI
{
    public class Controller : IController
    {
        private readonly IActionFactory _actionFactory;

        public Controller(IActionFactory actionFactory)
        {
            _actionFactory = actionFactory;
        }

        public void Run(string userInput)
        {
            var action = _actionFactory.Create(userInput);
            action.Execute();
        }
    }
}