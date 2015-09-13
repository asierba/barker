using System.Linq;
using Barker.App.Entities;
using Barker.Delivery.CLI;
using Barker.External.Repositories;

namespace Barker.App.Actions
{
    public class ShowWallCommand : ICommand
    {
        private readonly IBarkRepository _barkRepository;
        private readonly IPrinter _printer;

        public ShowWallCommand(string username, IBarkRepository barkRepository, IPrinter printer)
        {
            _barkRepository = barkRepository;
            _printer = printer;
            Username = username;
        }

        public void Execute()
        {
            var barks =_barkRepository.GetBarks(Username);
            _printer.PrintBarks(barks.OrderByDescending(x => x.Date));
        }

        public string Username { get; }
    }
}