using System;

namespace Barker.App.Entities
{
    public class Bark
    {
        public Bark(string username, string message, DateTime createdDate)
        {
            Username = username;
            Message = message;
            CreatedDate = createdDate;
        }

        public string Message { get; }
        public DateTime CreatedDate { get; }
        public string Username { get; private set; }
    }
}