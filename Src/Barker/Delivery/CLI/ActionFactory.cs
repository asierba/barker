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
        private const string ShowWallIdentifier = "wall";
        private const string FollowIfentifier = "follows";

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
            if (input.Contains(" " + FollowIfentifier))
                return CreateFollow(input);
            if (input.Contains(" " + ShowWallIdentifier))
                return CreateShowWall(input);
            if (input.Contains(MessageSeparator))
                return CreatePost(input);
            return CreateShowBarks(input);
        }

        private IAction CreateFollow(string input)
        {
            const string pattern = " " + FollowIfentifier;
            var username = input.Remove(input.LastIndexOf(pattern));
            var followingUsername = input.Substring(input.LastIndexOf(pattern) + pattern.Length + 1);
            return new Follow(username, followingUsername, _userRepository);
        }

        private IAction CreateShowWall(string input)
        {
            var username = input.Remove(input.LastIndexOf(" " + ShowWallIdentifier));
            return new ShowWall(username, _userRepository, _barksPrinter);
        }

        private IAction CreatePost(string input)
        {
            var inputChunks = input.Split(new[] {MessageSeparator}, StringSplitOptions.None);
            var username = inputChunks[0].Trim();
            var messages = inputChunks.Skip(1).Select(x => x.Trim()).ToList();
            return new Post(username, messages, _userRepository, _clock);
        }

        private IAction CreateShowBarks(string input)
        {
            var username = input.Trim();
            return new ShowBarks(username, _userRepository, _barksPrinter);
        }
    }
}