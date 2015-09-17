using System;
using System.Collections.Generic;
using Barker.App.Entities;

namespace Barkert.Tests.Helpers
{
    internal class UserBuilder
    {
        private string _name;
        private readonly List<Bark> _barks = new List<Bark>();
        private readonly List<User> _followingUsers = new List<User>();

        public static UserBuilder AUser()
        {
            return new UserBuilder();
        }

        public UserBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public UserBuilder WithBark(string message, DateTime date)
        {
            _barks.Add(new Bark(message, date));
            return this;
        }

        public UserBuilder WithBark(DateTime date)
        {
            _barks.Add(new Bark("An irrelevant message", date));
            return this;
        }

        public UserBuilder WithBark(string message)
        {
            var irrelevantDate = new DateTime();
            _barks.Add(new Bark(message, irrelevantDate));
            return this;
        }

        public UserBuilder Following(User user)
        {
            _followingUsers.Add(user);
            return this;
        }

        public User Build()
        {
            var user = new User(_name);
            _barks.ForEach(x => user.AddBark(x));
            _followingUsers.ForEach(x => user.AddFollowingUser(x));
            return user;
        }
    }
}