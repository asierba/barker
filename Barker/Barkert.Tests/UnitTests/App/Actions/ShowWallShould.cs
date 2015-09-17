using System;
using System.Collections.Generic;
using System.Linq;
using Barker.App.Actions;
using Barker.App.Entities;
using Barker.Delivery.CLI;
using Barker.External.Repositories;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests.App.Actions
{
    class ShowWallShould
    {
        private Mock<IBarksPrinter> _printer;
        private Mock<IUserRepository> _userRepository;
        private ShowWall _showWall;

        private readonly DateTime _now = DateTime.Now;
        private readonly DateTime _fiveHoursAgo = DateTime.Now.AddHours(-5);
        private readonly DateTime _yesterday = DateTime.Now.AddDays(-1);

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _printer = new Mock<IBarksPrinter>();
            _showWall = new ShowWall("Alice", _userRepository.Object, _printer.Object);
        }

        [Test] public void
        print_users_barks_in_time_descending_order()
        {
            var alice = new User("Alice");
            alice.AddBark(new Bark("A message 1", _fiveHoursAgo));
            alice.AddBark(new Bark("A message 2", _yesterday));
            alice.AddBark(new Bark("A message 3", _now));
            _userRepository.Setup(x => x.Get("Alice")).Returns(alice);

            _showWall.Execute();

            _printer.Verify(x => x.PrintBarks(It.Is<IEnumerable<Bark>>(y => y.ElementAt(0).Date == _now), "Alice"));
            _printer.Verify(x => x.PrintBarks(It.Is<IEnumerable<Bark>>(y => y.ElementAt(1).Date == _fiveHoursAgo), "Alice"));
            _printer.Verify(x => x.PrintBarks(It.Is<IEnumerable<Bark >>(y => y.ElementAt(2).Date == _yesterday), "Alice"));
        }

        [Test] public void
        print_barks_from_following_users()
        {
            var barkFromAlice = new Bark("a message from Alice", DateTime.Now.AddDays(-1));
            var barkFromBob = new Bark("a message from Bob", DateTime.Now.AddDays(-5));

            var alice = new User("Alice");
            var bob = new User("Bob");
            bob.AddBark(barkFromBob);
            alice.AddFollowingUser(bob);
            alice.AddBark(barkFromAlice);
            _userRepository.Setup(x => x.Get("Alice")).Returns(alice);

            _showWall.Execute();

            _printer.Verify(x => x.PrintBarks(It.Is<IEnumerable<Bark>>(y => y.Contains(barkFromAlice)), "Alice"));
            _printer.Verify(x => x.PrintBarks(It.Is<IEnumerable<Bark>>(y => y.Contains(barkFromBob)), "Bob"));
        }
    }
}
