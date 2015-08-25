using Barker.App.Actions;

namespace Barker.Delivery.CLI
{
    public interface ICommandFactory
    {
        ICommand Create(string input);
    }
}