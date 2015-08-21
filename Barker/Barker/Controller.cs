namespace Barker
{
    public class Controller
    {
        private readonly ICommandFactory _commandFactory;

        public Controller(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void Run(string input)
        {
            var command = _commandFactory.Create(input);
            command.Execute();
        }
    }
}