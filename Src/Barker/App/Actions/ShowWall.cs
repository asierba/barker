using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Barker.App.Entities;
using Barker.Delivery.CLI;
using Barker.External.Repositories;
using Castle.Core.Internal;

namespace Barker.App.Actions
{
    public class ShowWall : IAction
    {
        private readonly IUserRepository _userRepository;
        private readonly IBarksPrinter _barksPrinter;

        public ShowWall(string username, IUserRepository userRepository, IBarksPrinter barksPrinter)
        {
            Username = username;
            _barksPrinter = barksPrinter;
            _userRepository = userRepository;
        }

        public string Username { get; }

        public void Execute()
        {
            var mainUser = _userRepository.Get(Username);
            var followingUsers = mainUser.FollowingUsers;

            var allBarks = new ReadOnlyCollectionBuilder<Bark>(mainUser.Barks);
            followingUsers.ForEach(x => x.Barks.ForEach(y => allBarks.Add(y)));

            _barksPrinter.PrintMultipleUsersBarks(allBarks.OrderByDescending(x => x.CreatedDate));
        }
    }
}