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
    class ShowWallCommandShould
    {
        private static Mock<IBarkRepository> _barkRepository;
        private static Mock<IPrinter> _printer;
        private static ShowWallCommand _showWallCommand;

        private readonly DateTime _now = DateTime.Now;
        private readonly DateTime _fiveHoursAgo = DateTime.Now.AddHours(-5);
        private readonly DateTime _yesterday = DateTime.Now.AddDays(-1);

        [SetUp]
        public static void Setup()
        {
            _barkRepository = new Mock<IBarkRepository>();
            _printer = new Mock<IPrinter>();
            _showWallCommand = new ShowWallCommand("Alice", _barkRepository.Object, _printer.Object);
        }

        [Test]
        public void
        print_users_barks_in_time_descending_order()
        {
            _barkRepository.Setup(x => x.GetBarks("Alice"))
                .Returns(new List<Bark>
                {
                    new Bark("Alice", "Irrelevant", _fiveHoursAgo),
                    new Bark("Alice", "Irrelevant", _yesterday),
                    new Bark("Alice", "Irrelevant", _now)
                });

            _showWallCommand.Execute();

            _printer.Verify(x => x.PrintBarks(It.Is<IEnumerable<Bark>>(y => y.ElementAt(0).Date == _now)));
            _printer.Verify(x => x.PrintBarks(It.Is<IEnumerable<Bark>>(y => y.ElementAt(1).Date == _fiveHoursAgo)));
            _printer.Verify(x => x.PrintBarks(It.Is<IEnumerable<Bark >>(y => y.ElementAt(2).Date == _yesterday)));
        }
    }
}
