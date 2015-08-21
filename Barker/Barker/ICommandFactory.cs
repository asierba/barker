namespace Barker
{
    public interface ICommandFactory
    {
        ICommand Create(string input);
    }
}