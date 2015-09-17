using System.Linq;
using Barker.Delivery.CLI;
using Barker.External.Repositories;

namespace Barker.App.Actions
{
    public class ShowBarks : IAction
    {
        private readonly IUserRepository _userRepository;
        private readonly IPrinter _printer;

        public ShowBarks(string username, IUserRepository userRepository, IPrinter printer)
        {
            Username = username;
            _printer = printer;
           _userRepository = userRepository;
        }

        public string Username { get; }

        public void Execute()
        {
            var user = _userRepository.Get(Username);
            _printer.PrintBarks(user.Barks.OrderByDescending(x => x.Date));
        }
    }
}