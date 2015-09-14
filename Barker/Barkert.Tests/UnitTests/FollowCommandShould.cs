using System.Linq;
using Barker.App.Actions;
using Barker.App.Entities;
using Barker.External.Repositories;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests
{
    [TestFixture]
    class FollowCommandShould
    {
        private readonly User _charlie = new User("Charlie");
        private readonly User _allice = new User("Allice");
        private Mock<IUserRepository> _userRepository;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
        }

        [Test] public void 
        add_follower_to_the_repository()
        {
            var followCommand = new FollowCommand("Charlie", "Allice", _userRepository.Object);

            _userRepository.Setup(x => x.Get("Charlie")).Returns(_charlie);
            _userRepository.Setup(x => x.Get("Allice")).Returns(_allice);

            followCommand.Execute();

            Assert.Contains(_allice, _charlie.Following);
        } 
    }
}