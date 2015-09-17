using System.Collections.Generic;
using Barker.App.Entities;
using Barker.External;
using Barker.External.Repositories;
using Castle.Core.Internal;

namespace Barker.App.Actions
{
    public class Post : IAction
    {
        private readonly IUserRepository _userRepository;
        private readonly IClock _clock;

        public Post(string username, IList<string> message, IUserRepository userRepository, IClock clock)
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

            Messages.ForEach(x => user.AddBark(new Bark(x, _clock.Now)));
        }
    }
}