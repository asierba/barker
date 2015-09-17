using System;

namespace Barker.App.Entities
{
    public class Bark
    {
        public Bark(string message, DateTime date)
        {
            Message = message;
            Date = date;
        }

        public string Message { get; }
        public DateTime Date { get; }
    }
}