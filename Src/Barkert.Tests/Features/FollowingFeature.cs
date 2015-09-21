using System;
using System.IO;
using Barker.Delivery.CLI;
using Barker.External;
using Barkert.Tests.Helpers;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.Features
{
    [TestFixture]
    internal class FollowingFeature
    {

        private readonly DateTime _twoSecondsAgo = DateTime.Now.AddSeconds(-2);
        private readonly DateTime _fiveMinutesAgo = DateTime.Now.AddMinutes(-5);
        private readonly DateTime _eightHoursAgo = DateTime.Now.AddHours(-8);

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
        user_following_another_user_can_see_other_users_barks_in_wall()
        {
            MockConsoleInput(@"Charlie -> On my flight to New york
Alice->I love the weather today
Charlie -> I'm in New York today! Anyone want to have a coffee?
Charlie follows Alice
Charlie wall
EXIT");
            _clock.Setup(x => x.Now)
                .ReturnsInOrder(_eightHoursAgo, _fiveMinutesAgo, _twoSecondsAgo);
            _clock.Setup(x => x.GetTimePassedFrom(_eightHoursAgo)).Returns("8 hours");
            _clock.Setup(x => x.GetTimePassedFrom(_fiveMinutesAgo)).Returns("5 minutes");
            _clock.Setup(x => x.GetTimePassedFrom(_twoSecondsAgo)).Returns("2 seconds");

            Program.Main(new string[] { });

            Assert.That(_consoleOutput.ToString(), Is.StringEnding(
                @"Charlie - I'm in New York today! Anyone want to have a coffee?(2 seconds ago)
Alice - I love the weather today(5 minutes ago)
Charlie - On my flight to New york(8 hours ago)
Good bye!
"));
        }
    }
}