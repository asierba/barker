namespace Barker
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand Create(string input)
        {
            if(input.Contains("->"))
                return new PostCommand();
            return new ShowUserMessagesCommand();
        }
    }
}