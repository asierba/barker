using System.Collections.Generic;

namespace Barker
{
    public interface IBarkRepository
    {
        IList<Bark> GetBarks(string username);
    }
}