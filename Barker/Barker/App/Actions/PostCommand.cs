using System;
using System.Collections.Generic;
using Barker.App.Entities;
using Barker.Delivery.CLI;
using Barker.External.Repositories;

namespace Barker.App.Actions
{
    public class PostCommand : ICommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IClock _clock;

        public PostCommand(string username, IList<string> message, IUserRepository userRepository, IClock clock)
        {
            Username = username;
            Messages = message;
            _userRepository = userRepository;
            _clock = clock;
        }

        public string Username { get; }
        public IList<string> Messages { get; }

        public void Execute()
        {
            var user =_userRepository.Get(Username);
            if (user == null)
            {
                user = new User(Username);
                _userRepository.Add(user);
            }

            foreach (var message in Messages)
            {
                user.Barks.Add(new Bark(Username, message, _clock.Now));
            }
        }
    }
}