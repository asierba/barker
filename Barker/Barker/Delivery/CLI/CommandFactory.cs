using Barker.App.Actions;
using Barker.External.Repositories;

namespace Barker.Delivery.CLI
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IBarkRepository _barkRepository;
        private IPrinter _printer;

        public CommandFactory(IBarkRepository barkRepository, IPrinter printer)
        {
            _barkRepository = barkRepository;
            _printer = printer;
        }

        public ICommand Create(string input)
        {
            if(input.Contains("->"))
                return new PostCommand();
            return new ShowBarksCommand(input, _barkRepository, _printer);
        }
    }
}