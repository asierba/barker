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
            var user = _users.SingleOrDefault(x => x.Name == username);
            return user ?? new NotExistingUser();
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}