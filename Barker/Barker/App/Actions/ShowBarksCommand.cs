using System.Linq;
using Barker.Delivery.CLI;
using Barker.External.Repositories;

namespace Barker.App.Actions
{
    public class ShowBarksCommand : ICommand
    {
        private readonly IPrinter _printer;
        private readonly IBarkRepository _barkRepository;

        public ShowBarksCommand(string username, IBarkRepository barkRepository, IPrinter printer)
        {
            Username = username;
            _barkRepository = barkRepository;
            _printer = printer;
        }

        public string Username { get; }

        public void Execute()
        {
            var barks =_barkRepository.GetBarks(Username);
            var orderedBarks = barks.OrderByDescending(x => x.Date).ToList();
            _printer.PrintBarks(orderedBarks);
        }
    }
}