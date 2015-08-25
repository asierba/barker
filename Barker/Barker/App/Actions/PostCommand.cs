using System;
using System.Collections.Generic;
using System.Linq;
using Barker.App.Entities;
using Barker.External.Repositories;

namespace Barker.App.Actions
{
    public class PostCommand : ICommand
    {
        private readonly IBarkRepository _barkRepository;

        public PostCommand(string username, IList<string> message, IBarkRepository barkRepository)
        {
            Username = username;
            Messages = message;
            _barkRepository = barkRepository;
        }

        public string Username { get; }
        public IList<string> Messages { get; }

        public void Execute()
        {
            foreach (var message in Messages)
            {
                _barkRepository.Add(new Bark(Username, message, DateTime.Now));
            }
        }
    }
}