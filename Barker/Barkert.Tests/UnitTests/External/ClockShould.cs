using System;
using Barker.External;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests.External
{
    [TestFixture]
    class ClockShould
    {
        [TestCase(1, "1 second")]
        [TestCase(2, "2 seconds")]
        [TestCase(23, "23 seconds")]
        [TestCase(59, "59 seconds")]
        [TestCase(0, "0 seconds")]
        [TestCase(60, "1 minute")]
        [TestCase(2*60, "2 minutes")]
        [TestCase(60+1, "1 minute")]
        [TestCase(2*60-1, "1 minute")]
        [TestCase(60*60, "1 hour")]
        [TestCase(5*60*60, "5 hours")]
        [TestCase(24*60*60, "1 day")]
        [TestCase(3*24*60*60, "3 days")]
        [TestCase(3*24*60*60, "3 days")]
        public void
        get_time_difference(int seconds, string expected)
        {
            var clock = new Clock();
            var dateInPast = DateTime.Now.AddSeconds(-seconds);
            Assert.That(clock.GetTimeSpanned(dateInPast), Is.EqualTo(expected));
        }
    }
}
