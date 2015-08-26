using System;
using System.Collections.Generic;
using System.Linq;
using Barker.App.Entities;

namespace Barker.External.Repositories
{
    public class BarkRepository : IBarkRepository
    {
        private readonly List<Bark> _barks = new List<Bark>();

        public IList<Bark> GetBarks(string username)
        {
            return _barks.Where(x => x.Username == username).ToList();
        }

        public void Add(string username, string message)
        {
           _barks.Add(new Bark(username, message, DateTime.Now)); 
        }
    }
}