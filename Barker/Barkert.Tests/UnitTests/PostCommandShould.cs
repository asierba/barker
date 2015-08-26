using Barker.App.Actions;
using Barker.External.Repositories;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests
{
    [TestFixture]
    class PostCommandShould
    {
        [Test] public void 
        add_a_bark_to_the_repository()
        {
            var barkRepository = new Mock<IBarkRepository>();

            var messages = new[] { "a message"};
            var postCommand = new PostCommand("bob", messages, barkRepository.Object);

            postCommand.Execute();

            barkRepository.Verify(x => x.Add("bob", "a message"));
        }

        [Test]
        public void
        add_severals_bark_to_the_repository()
        {
            var barkRepository = new Mock<IBarkRepository>();

            var messages = new [] { "a message", "another message"};
            var postCommand = new PostCommand("bob", messages, barkRepository.Object);

            postCommand.Execute();

            barkRepository.Verify(x => x.Add("bob","a message"));
            barkRepository.Verify(x => x.Add("bob","another message"));
        }
    }
}
