using System.Collections.Generic;
using Barker.App.Entities;

namespace Barker.External.Repositories
{
    public interface IBarkRepository
    {
        IList<Bark> GetBarks(string username);
        void Add(Bark bark);
    }
}