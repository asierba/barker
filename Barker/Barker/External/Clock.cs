using System;

namespace Barker.External
{
    public class Clock : IClock
    {
        public string GetTimePassedFrom(DateTime dateTime)
        {
            var timeSpan = Now - dateTime;

            if (timeSpan.Days > 0)
                return Format(timeSpan.Days, "day");

            if (timeSpan.Hours > 0)
                return Format(timeSpan.Hours, "hour");

            if(timeSpan.Minutes > 0)
                return Format(timeSpan.Minutes, "minute");

            return Format(timeSpan.Seconds, "second");
        }

        public DateTime Now => DateTime.Now;

        private static string Format(int value, string type)
        {
            return $"{value} {type}{(value != 1 ? "s" : "")}";
        }
    }
}