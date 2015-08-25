using System;

namespace Barker.App.Entities
{
    public class Bark
    {
        public Bark(string username, string message, DateTime date)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}