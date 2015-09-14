using System.Collections.Generic;
using System.Linq;
using Barker.App.Entities;
using Barker.Delivery.CLI;
using Barker.External.Repositories;

namespace Barker.App.Actions
{
    public class ShowWallCommand : ICommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IPrinter _printer;

        public ShowWallCommand(string username, IUserRepository userRepository, IPrinter printer)
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