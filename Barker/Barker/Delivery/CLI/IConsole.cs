namespace Barker.Delivery.CLI
{
    public interface IConsole
    {
        void WriteLine(string value);
        string ReadLine();
    }
}