using System;

namespace Barker.App.Entities
{
    public class Bark
    {
        public Bark(string username, string message, DateTime date)
        {
            Username = username;
            Message = message;
            Date = date;
        }

        public string Message { get; }
        public string Username { get; }
        public DateTime Date { get; }
    }
}