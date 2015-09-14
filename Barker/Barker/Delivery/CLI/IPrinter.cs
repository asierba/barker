using System.Collections.Generic;
using Barker.App.Entities;

namespace Barker.Delivery.CLI
{
    public interface IPrinter
    {
        void PrintBarks(IEnumerable<Bark> barks);
        void PrintBarksWithUsername(IEnumerable<Bark> barks);
    }
}