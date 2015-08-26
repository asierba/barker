using System;

namespace Barker.Delivery.CLI
{
    public class Clock : IClock
    {
        public string GetTimeSpanned(DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;

            if (timeSpan.Days > 0)
                return Format(timeSpan.Days, "day");

            if (timeSpan.Hours > 0)
                return Format(timeSpan.Hours, "hour");

            if(timeSpan.Minutes > 0)
                return Format(timeSpan.Minutes, "minute");

            return Format(timeSpan.Seconds, "second");
        }

        private static string Format(int value, string type)
        {
            return $"{value} {type}{(value != 1 ? "s" : "")}";
        }
    }
}