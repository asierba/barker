using System.Linq;
using Barker.Delivery.CLI;
using Barker.External.Repositories;

namespace Barker.App.Actions
{
    public class ShowWall : IAction
    {
        private readonly IUserRepository _userRepository;
        private readonly IPrinter _printer;

        public ShowWall(string username, IUserRepository userRepository, IPrinter printer)
        {
            Username = username;
            _printer = printer;
            _userRepository = userRepository;
        }

        public string Username { get; }

        public void Execute()
        {
            var user = _userRepository.Get(Username);
            var barks = user.Barks;

            foreach (var followingUser in user.Following)
            {
                barks.AddRange(followingUser.Barks);
            }

            _printer.PrintBarksWithUsername(barks.OrderByDescending(x => x.Date));
        }
    }
}