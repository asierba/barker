using System;
using System.Linq;
using Barker.App.Actions;
using Barker.External.Repositories;

namespace Barker.Delivery.CLI
{
    public class CommandFactory : ICommandFactory
    {
        private const string MessageSeparator = "->";

        private readonly IBarkRepository _barkRepository;
        private readonly IPrinter _printer;

        public CommandFactory(IBarkRepository barkRepository, IPrinter printer)
        {
            _barkRepository = barkRepository;
            _printer = printer;
        }

        public ICommand Create(string input)
        {
            if (input.Contains(" follows"))
            {
                var username = input.Remove(input.LastIndexOf(" follows"));
                var following = input.Substring(input.LastIndexOf(" follows") + " follows".Length + 1);
                return new FollowCommand(username, following);
            }
            if (input.Contains(" wall"))
            {
                var username = input.Remove(input.LastIndexOf(" wall"));
                return new ShowWallCommand(username, _barkRepository, _printer);
            }
            if (input.Contains(MessageSeparator))
            {
                var inputChunks = input.Split(new[] { MessageSeparator }, StringSplitOptions.None);
                var username = inputChunks[0].Trim();
                var messages = inputChunks.Skip(1).Select(x => x.Trim()).ToList();
                return new PostCommand(username, messages, _barkRepository);
            }
            return new ShowBarksCommand(input.Trim(), _barkRepository, _printer);
        }
    }
}