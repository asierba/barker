using System;
using System.Linq;
using Barker.App.Actions;
using Barker.External;
using Barker.External.Repositories;

namespace Barker.Delivery.CLI
{
    public class ActionFactory : IActionFactory
    {
        private const string MessageSeparator = "->";

        private readonly IUserRepository _userRepository;
        private readonly IBarksPrinter _barksPrinter;
        private readonly IClock _clock;

        public ActionFactory(IUserRepository userRepository, IBarksPrinter barksPrinter, IClock clock)
        {
            _userRepository = userRepository;
            _barksPrinter = barksPrinter;
            _clock = clock;
        }

        public IAction Create(string input)
        {
            if (input.Contains(" follows"))
            {
                var username = input.Remove(input.LastIndexOf(" follows"));
                var following = input.Substring(input.LastIndexOf(" follows") + " follows".Length + 1);
                return new Follow(username, following, _userRepository);
            }
            if (input.Contains(" wall"))
            {
                var username = input.Remove(input.LastIndexOf(" wall"));
                return new ShowWall(username, _userRepository, _barksPrinter);
            }
            if (input.Contains(MessageSeparator))
            {
                var inputChunks = input.Split(new[] { MessageSeparator }, StringSplitOptions.None);
                var username = inputChunks[0].Trim();
                var messages = inputChunks.Skip(1).Select(x => x.Trim()).ToList();
                return new Post(username, messages, _userRepository, _clock);
            }
            return new ShowBarks(input.Trim(), _userRepository, _barksPrinter);
        }
    }
}