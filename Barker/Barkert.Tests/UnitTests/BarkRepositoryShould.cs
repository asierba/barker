using System;
using System.Linq;
using Barker.App.Entities;
using Barker.External.Repositories;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests
{
    [TestFixture]
    class BarkRepositoryShould
    {
        [Test] public void 
        get_barks_for_a_user()
        {
            IBarkRepository barkRepository = new BarkRepository();
            barkRepository.Add(new Bark("Alice", "I love the weather today! :)", new DateTime(2015, 8, 22, 1, 7, 0)));
            barkRepository.Add(new Bark("Alice", "Hope I can go to the swimming pool..", new DateTime(2015, 8, 22, 5, 27, 0)));
            barkRepository.Add(new Bark("Bob", "Hi, this is Bob", new DateTime(2015, 8, 23, 3, 0, 0)));

            var barks = barkRepository.GetBarks("Alice");

            Assert.True(barks.All(x => x.Username == "Alice"));
        }
    }
}
