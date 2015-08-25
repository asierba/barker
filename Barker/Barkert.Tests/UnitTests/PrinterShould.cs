using System;
using System.Collections.Generic;
using System.IO;
using Barker;
using Barker.App.Entities;
using Barker.Delivery.CLI;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests
{
    [TestFixture]
    class PrinterShould
    {
        private StringWriter _consoleOutput;

        [SetUp]
        public void MockConsoleOutput()
        {
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);
        }

        [Test] public void
        print_in_console_barks()
        {
            var printer = new Printer();
            var barks = new List<Bark>
            {
                new Bark("Alice", "I love the weather today! :)", new DateTime(2015, 8, 22, 1, 7, 0)),
                new Bark("Alice", "Hope I can go to the swimming pool..", new DateTime(2015, 8, 22, 5, 27, 0)),
            };

            printer.PrintBarks(barks);

            Assert.That(_consoleOutput.ToString(), Is.StringEnding(@"I love the weather today! :)
Hope I can go to the swimming pool..
"));
        }
    }
}
