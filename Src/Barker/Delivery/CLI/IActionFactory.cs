using Barker.App.Actions;

namespace Barker.Delivery.CLI
{
    public interface IActionFactory
    {
        IAction Create(string input);
    }
}