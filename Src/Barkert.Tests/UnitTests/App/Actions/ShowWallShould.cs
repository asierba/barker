using System;
using System.Collections.Generic;
using System.Linq;
using Barker.App.Actions;
using Barker.App.Entities;
using Barker.Delivery.CLI;
using Barker.External.Repositories;
using Barkert.Tests.Helpers;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests.App.Actions
{
    class ShowWallShould
    {
        private Mock<IBarksPrinter> _barksPrinter;
        private Mock<IUserRepository> _userRepository;
        private ShowWall _showWall;

        private readonly DateTime _threeSecondsAgo = DateTime.Now.AddSeconds(-3);
        private readonly DateTime _fiveHoursAgo = DateTime.Now.AddHours(-5);
        private readonly DateTime _yesterday = DateTime.Now.AddDays(-1);

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _barksPrinter = new Mock<IBarksPrinter>();
            _showWall = new ShowWall("Alice", _userRepository.Object, _barksPrinter.Object);
        }

        [Test] public void
        print_users_barks_in_time_descending_order()
        {
            var alice = UserBuilder.AUser()
                .WithName("Alice")
                .WithBark(_fiveHoursAgo)
                .WithBark(_yesterday)
                .WithBark(_threeSecondsAgo)
                .Build();

            _userRepository.Setup(x => x.Get("Alice")).Returns(alice);

            _showWall.Execute();

            _barksPrinter.Verify(x => x.PrintMultipleUsersBarks(It.Is<IEnumerable<Bark>>(y => y.ElementAt(0).CreatedDate == _threeSecondsAgo)));
            _barksPrinter.Verify(x => x.PrintMultipleUsersBarks(It.Is<IEnumerable<Bark>>(y => y.ElementAt(1).CreatedDate == _fiveHoursAgo)));
            _barksPrinter.Verify(x => x.PrintMultipleUsersBarks(It.Is<IEnumerable<Bark >>(y => y.ElementAt(2).CreatedDate == _yesterday)));
        }

        [Test] public void
        print_user_barks_from_current_user_and_following_users()
        {
            var bob = UserBuilder.AUser()
                .WithName("Bob")
                .WithBark("a message from Bob")
                .Build();
            var alice = UserBuilder.AUser()
                .WithName("Alice")
                .WithBark("a message from Alice")
                .Following(bob)
                .Build();
            _userRepository.Setup(x => x.Get("Alice")).Returns(alice);

            _showWall.Execute();

            _barksPrinter.Verify(x => x.PrintMultipleUsersBarks(It.Is<IEnumerable<Bark>>(y => y.Any(z => z.Message == "a message from Alice"))));
            _barksPrinter.Verify(x => x.PrintMultipleUsersBarks(It.Is<IEnumerable<Bark>>(y => y.Any(z => z.Message == "a message from Bob"))));
        }

        [Test]
        public void
                print_user_barks_from_current_user_and_following_users_in_time_descending_order()
        {
            var bob = UserBuilder.AUser()
                .WithName("Bob")
                .WithBark("a message from Bob", _threeSecondsAgo )
                .Build();
            var alice = UserBuilder.AUser()
                .WithName("Alice")
                .WithBark("a message from Alice", _fiveHoursAgo)
                .Following(bob)
                .Build();
            _userRepository.Setup(x => x.Get("Alice")).Returns(alice);

            _showWall.Execute();

            _barksPrinter.Verify(x => x.PrintMultipleUsersBarks(It.Is<IEnumerable<Bark>>(y => y.ElementAt(0).CreatedDate == _threeSecondsAgo)));
            _barksPrinter.Verify(x => x.PrintMultipleUsersBarks(It.Is<IEnumerable<Bark>>(y => y.ElementAt(1).CreatedDate == _fiveHoursAgo)));
        }
    }
}
