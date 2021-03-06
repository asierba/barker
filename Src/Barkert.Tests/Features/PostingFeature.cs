﻿using System;
using System.IO;
using Barker.Delivery.CLI;
using Barker.External;
using Barkert.Tests.Helpers;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.Features
{
    [TestFixture]
    class PostingFeature
    {
        private readonly DateTime _oneMinuteAgo = DateTime.Now.AddMinutes(-1);
        private readonly DateTime _twoMinutesAgo = DateTime.Now.AddMinutes(-2);
        private readonly DateTime _fiveMinutesAgo = DateTime.Now.AddMinutes(-5);

        private StringWriter _consoleOutput;
        private Mock<IClock> _clock;

        [SetUp]
        public void MockConsoleOutput()
        {
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);
        }

        [SetUp]
        public void MockClock()
        {
            _clock = new Mock<IClock>();
            Program.Container.OverrideRegister(_clock.Object);
        }

        private static void MockConsoleInput(string input)
        {
            Console.SetIn(new StringReader(input));
        }

        [Test] public void
        user_can_publish_and_view_barks_from_a_timeline()
        {
            MockConsoleInput(@"Alice->I love the weather today
Bob->Damn!We lost!
Bob->Good game though.
Alice
Bob
EXIT");
            _clock.Setup(x => x.Now)
                .ReturnsInOrder(_fiveMinutesAgo, _twoMinutesAgo, _oneMinuteAgo);
            _clock.Setup(x => x.GetTimePassedFrom(_fiveMinutesAgo)).Returns("5 minutes");
            _clock.Setup(x => x.GetTimePassedFrom(_twoMinutesAgo)).Returns("2 minutes");
            _clock.Setup(x => x.GetTimePassedFrom(_oneMinuteAgo)).Returns("1 minute");


            Program.Main(new string[] { });

            Assert.That(_consoleOutput.ToString(), Is.StringEnding(@"I love the weather today(5 minutes ago)
Good game though.(1 minute ago)
Damn!We lost!(2 minutes ago)
Good bye!
"));
        }
    }
}
