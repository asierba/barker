namespace Barker
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand Create(string input)
        {
            return new ShowUserMessagesCommand();
        }
    }
}