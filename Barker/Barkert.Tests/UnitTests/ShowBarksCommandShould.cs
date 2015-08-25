using System;
using System.Collections.Generic;
using Barker;
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
        [Test] public void
        print_users_barks()
        {
            var username = "Alice";
            var barkRepository = new Mock<IBarkRepository>();
            var printer = new Mock<IPrinter>();
            var showUserMessagesCommand = new ShowBarksCommand(username, barkRepository.Object, printer.Object);

            var barks = new List<Bark>
            {
                new Bark("Alice", "I love the weather today! :)", new DateTime(2015, 8, 22, 1, 7, 0)),
                new Bark("Alice", "Hope I can go to the swimming pool..", new DateTime(2015, 8, 22, 5, 27, 0)),
            };
            barkRepository.Setup(x => x.GetBarks(username))
                .Returns(barks);

            showUserMessagesCommand.Execute();

            printer.Verify(x => x.PrintBarks(barks));
        }
    }
}
