using System;
using System.Collections.Generic;
using Barker.App.Entities;
using Barker.Delivery.CLI;
using Barker.External;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests
{
    [TestFixture]
    class PrinterShould
    {
        private readonly DateTime _fiveMinutesAgo = new DateTime(2015, 8, 22, 7, 22, 0);
        private readonly DateTime _twoHoursAgo = new DateTime(2015, 8, 22, 5, 27, 0);
        private Mock<IConsole> _console;
        private Mock<IClock> _clock;
        private Printer _printer;

        [SetUp]
        public void Setup()
        {
            _console = new Mock<IConsole>();
            _clock = new Mock<IClock>();
            _printer = new Printer(_console.Object, _clock.Object);
        }

        [Test] public void
        print_barks_in_console_with_time()
        {
            var barks = new List<Bark>
            {
                new Bark("Alice", "I love the weather today! :)", _fiveMinutesAgo),
                new Bark("Alice", "Hope I can go to the swimming pool..", _twoHoursAgo),
            };
           _clock.Setup(x => x.GetTimeSpanned(_fiveMinutesAgo))
               .Returns("5 mins");
            _clock.Setup(x => x.GetTimeSpanned(_twoHoursAgo))
               .Returns("2 hours");

            _printer.PrintBarks(barks);

            _console.Verify(x => x.WriteLine("I love the weather today! :)(5 mins ago)"));
            _console.Verify(x => x.WriteLine("Hope I can go to the swimming pool..(2 hours ago)"));
        }

        [Test]
        public void
        print_barks_in_console_with_username()
        {
            var barks = new List<Bark>
            {
                new Bark("Alice", "I love the weather today! :)", _fiveMinutesAgo),
                new Bark("Alice", "Hope I can go to the swimming pool..", _twoHoursAgo),
            };
            _clock.Setup(x => x.GetTimeSpanned(_fiveMinutesAgo))
                .Returns("5 mins");
            _clock.Setup(x => x.GetTimeSpanned(_twoHoursAgo))
               .Returns("2 hours");

            _printer.PrintBarksWithUsername(barks);

            _console.Verify(x => x.WriteLine("Alice - I love the weather today! :)(5 mins ago)"));
            _console.Verify(x => x.WriteLine("Alice - Hope I can go to the swimming pool..(2 hours ago)"));
        }
    }
}
