using System.Collections.Generic;
using System.Linq;
using Barker.App.Entities;

namespace Barker.External.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public User Get(string username)
        {
            return _users.SingleOrDefault(x => x.Name == username);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}