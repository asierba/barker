using System.Collections.Generic;
using Barker.App.Entities;

namespace Barker.Delivery.CLI
{
    public interface IBarksPrinter
    {
        void PrintSingleUserBarks(IEnumerable<Bark> barks);
        void PrintMultipleUsersBarks(IEnumerable<Bark> barks);
    }
}