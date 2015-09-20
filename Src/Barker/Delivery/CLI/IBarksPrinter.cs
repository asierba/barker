using System.Collections.Generic;
using Barker.App.Entities;

namespace Barker.Delivery.CLI
{
    public interface IBarksPrinter
    {
        void PrintBarks(IEnumerable<Bark> barks);
        void PrintBarks(IEnumerable<Bark> barks, string username);
    }
}