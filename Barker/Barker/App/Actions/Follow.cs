using Barker.External.Repositories;

namespace Barker.App.Actions
{
    public class Follow : IAction
    {
        private readonly IUserRepository _userRepository;

        public Follow(string username, string followingUsername, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            Username = username;
            FollowingUsername = followingUsername;
        }

        public string Username { get; }
        public string FollowingUsername { get; }

        public void Execute()
        {
            var user = _userRepository.Get(Username);
            var userToFollow = _userRepository.Get(FollowingUsername);
            user.AddFollowingUser(userToFollow);
        }
    }
}