using System.Linq;
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
            var user = _userRepository.Get(Username);

            _barksPrinter.PrintBarks(user.Barks.OrderByDescending(x => x.CreatedDate), Username);

            user.FollowingUsers.ForEach(x => _barksPrinter.PrintBarks(x.Barks.OrderByDescending(y => y.CreatedDate), x.Name));
        }
    }
}