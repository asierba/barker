namespace Barker.App.Actions
{
    public class FollowCommand : ICommand
    {
        public FollowCommand(string username, string following)
        {
            Username = username;
            Following = following;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        public string Username { get; }
        public string Following { get; }
    }
}