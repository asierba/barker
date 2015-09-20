using System;

namespace Barker.App.Entities
{
    public class Bark
    {
        public Bark(string message, DateTime createdDate)
        {
            Message = message;
            CreatedDate = createdDate;
        }

        public string Message { get; }
        public DateTime CreatedDate { get; }
    }
}