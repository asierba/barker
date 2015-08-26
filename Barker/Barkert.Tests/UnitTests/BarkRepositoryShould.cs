using System.Linq;
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

            barkRepository.Add("Alice", "I love the weather today! :)");
            barkRepository.Add("Alice", "Hope I can go to the swimming pool..");
            barkRepository.Add("Bob", "Hi, this is Bob");

            var barks = barkRepository.GetBarks("Alice");

            Assert.That(barks.Count, Is.EqualTo(2));
            Assert.True(barks.All(x => x.Username == "Alice"));
        }
    }
}
