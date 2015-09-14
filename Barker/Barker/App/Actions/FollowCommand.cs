using Barker.External.Repositories;

namespace Barker.App.Actions
{
    public class FollowCommand : ICommand
    {
        private readonly IUserRepository _userRepository;

        public FollowCommand(string username, string following, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            Username = username;
            Following = following;
        }

        public string Username { get; }
        public string Following { get; }

        public void Execute()
        {
            var user = _userRepository.Get(Username);
            var toFollow = _userRepository.Get(Following);
            user.Following.Add(toFollow);
        }
    }
}