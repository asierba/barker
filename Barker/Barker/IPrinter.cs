using System.Collections.Generic;

namespace Barker
{
    public interface IPrinter
    {
        void PrintBarks(IEnumerable<Bark> barks);
    }
}