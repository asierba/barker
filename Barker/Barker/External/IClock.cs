using System;

namespace Barker.External
{
    public interface IClock
    {
        string GetTimePassedFrom(DateTime dateTime);
        DateTime Now { get; }
    }
}