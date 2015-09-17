using System;

namespace Barker.External
{
    public interface IClock
    {
        string GetTimeSpanned(DateTime dateTime);
        DateTime Now { get; }
    }
}