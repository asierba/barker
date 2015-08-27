using System;

namespace Barker.Delivery.CLI
{
    public interface IClock
    {
        string GetTimeSpanned(DateTime dateTime);
        DateTime Now { get; }
    }
}