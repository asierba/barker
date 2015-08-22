using System;

namespace Barker
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