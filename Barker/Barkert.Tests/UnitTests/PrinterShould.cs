using System;
using System.Collections.Generic;
using System.IO;
using Barker.App.Entities;
using Barker.Delivery.CLI;
using NUnit.Framework;
using Moq;

namespace Barkert.Tests.UnitTests
{
    [TestFixture]
    class PrinterShould
    {
       [Test] public void
        print_barks_in_console()
        {
            var console = new Mock<IConsole>();
            var printer = new Printer(console.Object);

            var barks = new List<Bark>
            {
                new Bark("Alice", "I love the weather today! :)", new DateTime(2015, 8, 22, 1, 7, 0)),
                new Bark("Alice", "Hope I can go to the swimming pool..", new DateTime(2015, 8, 22, 5, 27, 0)),
            };

            printer.PrintBarks(barks);

            console.Verify(x => x.WriteLine("I love the weather today! :)"));
            console.Verify(x => x.WriteLine("Hope I can go to the swimming pool.."));
        }
    }
}
