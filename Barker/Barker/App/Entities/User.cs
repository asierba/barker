using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Barker.App.Entities
{
    public class User
    {
        public User(string name)
        {
            Name = name;
            FollowingUsers = new ReadOnlyCollection<User>(new List<User>());
            Barks = new ReadOnlyCollection<Bark>(new List<Bark>());
        }

        public string Name { get; }
        public ReadOnlyCollection<User> FollowingUsers { get; private set; }
        public ReadOnlyCollection<Bark> Barks { get; private set; }

        public void AddBark(Bark bark)
        {
            Barks = new ReadOnlyCollectionBuilder<Bark>(Barks) {bark}.ToReadOnlyCollection();
        }

        public void AddFollowingUser(User user)
        {
            FollowingUsers = new ReadOnlyCollectionBuilder<User>(FollowingUsers) {user}.ToReadOnlyCollection();
        }
    }
}