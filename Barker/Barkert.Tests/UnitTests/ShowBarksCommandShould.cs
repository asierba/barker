using System;
using System.Collections.Generic;
using System.Linq;
using Barker.App.Actions;
using Barker.App.Entities;
using Barker.Delivery.CLI;
using Barker.External.Repositories;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests
{
    [TestFixture]
    class ShowBarksCommandShould
    {
        private static Mock<IPrinter> _printer;
        private static Mock<IUserRepository> _userRepository;
        private static ShowBarksCommand _showUserMessagesCommand;

        private readonly DateTime _now = DateTime.Now;
        private readonly DateTime _fiveHoursAgo = DateTime.Now.AddHours(-5);
        private readonly DateTime _yesterday = DateTime.Now.AddDays(-1);

        [SetUp]
        public static void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _printer = new Mock<IPrinter>();
            _showUserMessagesCommand = new ShowBarksCommand("Alice", _userRepository.Object, _printer.Object);
        }

        [Test] public void
        print_users_barks_in_time_descending_order()
        {
            var alice = new User("alice");
            alice.Barks.Add(new Bark("Alice", "Irrelevant", _fiveHoursAgo));
            alice.Barks.Add(new Bark("Alice", "Irrelevant", _yesterday));
            alice.Barks.Add(new Bark("Alice", "Irrelevant", _now));
            _userRepository.Setup(x => x.Get("Alice")).Returns(alice);

            _showUserMessagesCommand.Execute();

            _printer.Verify(x => x.PrintBarks(It.Is<IEnumerable<Bark>>(y => y.ElementAt(0).Date == _now)));
            _printer.Verify(x => x.PrintBarks(It.Is<IEnumerable<Bark>>(y => y.ElementAt(1).Date == _fiveHoursAgo)));
            _printer.Verify(x => x.PrintBarks(It.Is<IEnumerable<Bark>>(y => y.ElementAt(2).Date == _yesterday)));
        }
    }
}
