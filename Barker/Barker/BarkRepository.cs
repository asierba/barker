using System.Collections.Generic;

namespace Barker
{
    public class BarkRepository : IBarkRepository
    {
        public IList<Bark> GetBarks(string username)
        {
            return new List<Bark>();
        }
    }
}