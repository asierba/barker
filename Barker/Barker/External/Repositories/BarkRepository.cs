using System;
using System.Collections.Generic;
using System.Linq;
using Barker.App.Entities;
using Barker.Delivery.CLI;

namespace Barker.External.Repositories
{
    public class BarkRepository : IBarkRepository
    {
        private readonly IClock _clock;
        private readonly List<Bark> _barks = new List<Bark>();

        public BarkRepository(IClock clock)
        {
            _clock = clock;
        }

        public IList<Bark> GetBarks(string username)
        {
            return _barks.Where(x => x.Username == username).ToList();
        }

        public void Add(string username, string message)
        {
           _barks.Add(new Bark(username, message, _clock.Now)); 
        }
    }
}