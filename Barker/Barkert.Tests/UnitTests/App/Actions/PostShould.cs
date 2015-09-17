using System.Linq;
using Barker.App.Actions;
using Barker.App.Entities;
using Barker.External;
using Barker.External.Repositories;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests.App.Actions
{
    [TestFixture]
    class PostShould
    {
        private Mock<IClock> _clock;
        private Mock<IUserRepository> _userRepository;

        private readonly User _bob = new User("bob");

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _clock = new Mock<IClock>();
        }

        [Test] public void 
        add_a_bark_to_the_user()
        {
            var messages = new[] { "a message"};
            var post = new Post("bob", messages, _userRepository.Object, _clock.Object);
            _userRepository.Setup(x => x.Get("bob")).Returns(_bob);

            post.Execute();

            Assert.That(_bob.Barks.Any(x => x.Message == "a message"), "bark not present in user");
        }

        [Test] public void
        add_severals_bark_to_the_user()
        {
            var messages = new [] { "a message", "another message"};
            var post = new Post("bob", messages, _userRepository.Object, _clock.Object);
            _userRepository.Setup(x => x.Get("bob")).Returns(_bob);

            post.Execute();

            Assert.That(_bob.Barks.Any(x => x.Message == "a message"), "bark not present in user");
            Assert.That(_bob.Barks.Any(x => x.Message == "another message"), "bark not present in user");
        }

        [Test] public void 
        create_a_user_if_it_doesnt_exists()
        {
            var messages = new[] { "a message" };
            var post = new Post("mike", messages, _userRepository.Object, _clock.Object);
            _userRepository.Setup(x => x.Get("mike")).Returns((User) null);

            post.Execute();

            _userRepository.Verify(x => x.Add(It.Is<User>(y => y.Name == "mike")));
        }

    }
}
