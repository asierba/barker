using System;
using System.Collections.Generic;
using Barker.App.Entities;

namespace Barker.External.Repositories
{
    public class BarkRepository : IBarkRepository
    {
        public IList<Bark> GetBarks(string username)
        {
            throw new NotImplementedException();
        }
    }
}