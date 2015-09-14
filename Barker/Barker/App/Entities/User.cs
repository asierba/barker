using System.Collections.Generic;

namespace Barker.App.Entities
{
    public class User
    {
        public User(string name)
        {
            Name = name;
            Following = new List<User>();
            Barks = new List<Bark>();
        }

        public string Name { get; }
        public List<User> Following { get; }
        public List<Bark> Barks { get; set; }
    }
}