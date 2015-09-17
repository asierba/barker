using Barker.App.Entities;
using Barker.External.Repositories;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests.External.Repositories
{
    [TestFixture]
    class UserRepositoryShould
    {
        [Test]
        public void get_user_by_username()
        {
            var userRepository = new UserRepository();

            userRepository.Add(new User("bob"));

            var user = userRepository.Get("bob");

            Assert.That(user.Name, Is.EqualTo("bob"));
        }
    }
}
