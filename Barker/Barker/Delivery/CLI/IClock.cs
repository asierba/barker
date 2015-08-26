using System;

namespace Barker.Delivery.CLI
{
    public interface IClock
    {
        string GetDifference(DateTime dateTime);
    }
}