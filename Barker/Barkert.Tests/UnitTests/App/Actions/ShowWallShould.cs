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
        private Mock<IPrinter> _printer;
        private Mock<IUserRepository> _userRepository;
        private ShowWall _showWall;

        private readonly DateTime _now = DateTime.Now;
        private readonly DateTime _fiveHoursAgo = DateTime.Now.AddHours(-5);
        private readonly DateTime _yesterday = DateTime.Now.AddDays(-1);

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _printer = new Mock<IPrinter>();
            _showWall = new ShowWall("Alice", _userRepository.Object, _printer.Object);
        }

        [Test] public void
        print_users_barks_in_time_descending_order()
        {
            var alice = new User("Alice");
            alice.Barks.Add(new Bark("Alice", "Irrelevant", _fiveHoursAgo));
            alice.Barks.Add(new Bark("Alice", "Irrelevant", _yesterday));
            alice.Barks.Add(new Bark("Alice", "Irrelevant", _now));
            _userRepository.Setup(x => x.Get("Alice")).Returns(alice);
            _userRepository.Setup(x => x.Get("Alice")).Returns(alice);
            _showWall.Execute();

            _printer.Verify(x => x.PrintBarksWithUsername(It.Is<IEnumerable<Bark>>(y => y.ElementAt(0).Date == _now)));
            _printer.Verify(x => x.PrintBarksWithUsername(It.Is<IEnumerable<Bark>>(y => y.ElementAt(1).Date == _fiveHoursAgo)));
            _printer.Verify(x => x.PrintBarksWithUsername(It.Is<IEnumerable<Bark >>(y => y.ElementAt(2).Date == _yesterday)));
        }

        [Test] public void
        print_barks_from_following_users()
        {
            var barkFromAlice = new Bark("Alice", "a message", DateTime.Now.AddDays(-1));
            var barkFromBob = new Bark("Bob", "a message", DateTime.Now.AddDays(-5));

            var alice = new User("Alice");
            var bob = new User("Bob");
            bob.Barks.Add(barkFromBob);
            alice.Following.Add(bob);
            alice.Barks.Add(barkFromAlice);
            _userRepository.Setup(x => x.Get("Alice")).Returns(alice);

            _showWall.Execute();

            _printer.Verify(x => x.PrintBarksWithUsername(It.Is<IEnumerable<Bark>>(y => y.Contains(barkFromAlice))));
            _printer.Verify(x => x.PrintBarksWithUsername(It.Is<IEnumerable<Bark>>(y => y.Contains(barkFromBob))));
        }
    }
}
