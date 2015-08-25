using Barker.Delivery.CLI;
using Barker.External.Repositories;

namespace Barker.App.Actions
{
    public class ShowBarksCommand : ICommand
    {
        private readonly IPrinter _printer;
        private readonly string _username;
        private readonly IBarkRepository _barkRepository;

        public ShowBarksCommand(string username, IBarkRepository barkRepository, IPrinter printer)
        {
            _username = username;
            _barkRepository = barkRepository;
            _printer = printer;
        }

        public void Execute()
        {
            var barks =_barkRepository.GetBarks(_username);
            _printer.PrintBarks(barks);
        }
    }
}