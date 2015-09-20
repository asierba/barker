using Barker.App.Entities;
using Barker.External.Repositories;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests.External.Repositories
{
    [TestFixture]
    class UserRepositoryShould
    {
        [Test] public void 
        get_user_by_username()
        {
            var userRepository = new UserRepository();

            userRepository.Add(new User("bob"));

            var user = userRepository.Get("bob");

            Assert.That(user.Name, Is.EqualTo("bob"));
        }

        [Test] public void 
        get_no_user_if_not_present()
        {
            var userRepository = new UserRepository();

            var user = userRepository.Get("mike");

            Assert.That(user, Is.TypeOf<NotExistingUser>());
        }
    }
}
