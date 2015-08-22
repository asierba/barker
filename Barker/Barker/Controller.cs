namespace Barker
{
    public class Controller : IController
    {
        private readonly ICommandFactory _commandFactory;

        public Controller(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void Run(string userInput)
        {
            var command = _commandFactory.Create(userInput);
            command.Execute();
        }
    }
}