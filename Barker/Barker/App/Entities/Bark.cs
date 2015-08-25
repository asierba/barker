using System;

namespace Barker.App.Entities
{
    public class Bark
    {
        public Bark(string username, string message, DateTime date)
        {
            Username = username;
            Message = message;
        }

        public string Message { get; private set; }
        public string Username { private set; get; }
    }
}