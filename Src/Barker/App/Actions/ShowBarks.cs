using System.Linq;
using Barker.Delivery.CLI;
using Barker.External.Repositories;

namespace Barker.App.Actions
{
    public class ShowBarks : IAction
    {
        private readonly IUserRepository _userRepository;
        private readonly IBarksPrinter _barksPrinter;

        public ShowBarks(string username, IUserRepository userRepository, IBarksPrinter barksPrinter)
        {
            Username = username;
            _barksPrinter = barksPrinter;
           _userRepository = userRepository;
        }

        public string Username { get; }

        public void Execute()
        {
            var user = _userRepository.Get(Username);
            _barksPrinter.PrintSingleUserBarks(user.Barks.OrderByDescending(x => x.CreatedDate));
        }
    }
}