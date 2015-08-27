using System;
using System.Linq;
using Barker.Delivery.CLI;
using Barker.External.Repositories;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests
{
    [TestFixture]
    class BarkRepositoryShould
    {
        private readonly DateTime _aDateTime = DateTime.Now.AddMinutes(-6);

        private Mock<IClock> _clock;
        private IBarkRepository _barkRepository;

        [SetUp]
        public void Setup()
        {
            _clock = new Mock<IClock>();
            _barkRepository = new BarkRepository(_clock.Object);
        }

        [Test] public void 
        get_barks_for_a_user()
        {
            _clock.Setup(x => x.Now).Returns(_aDateTime);

            _barkRepository.Add("Alice", "I love the weather today! :)");
            _barkRepository.Add("Alice", "Hope I can go to the swimming pool..");
            _barkRepository.Add("Bob", "Hi, this is Bob");

            var barks = _barkRepository.GetBarks("Alice");

            Assert.That(barks.Count, Is.EqualTo(2));
            Assert.True(barks.All(x => x.Username == "Alice"));
            Assert.That(barks[0].Date, Is.EqualTo(_aDateTime));
            Assert.That(barks[1].Date, Is.EqualTo(_aDateTime));
        }
    }
}
