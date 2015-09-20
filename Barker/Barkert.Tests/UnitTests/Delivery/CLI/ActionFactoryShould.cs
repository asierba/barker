using Barker.App.Actions;
using Barker.Delivery.CLI;
using Barker.External;
using Barker.External.Repositories;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests.Delivery.CLI
{
    [TestFixture]
    class ActionFactoryShould
    {
        private ActionFactory _actionFactory;

        [SetUp]
        public void Setup()
        {
            _actionFactory = new ActionFactory(new Mock<IUserRepository>().Object,  new Mock<IBarksPrinter>().Object, new Mock<IClock>().Object);
        }

        [Test] public void
        create_show_user_barks_action_when_input_contains_just_username()
        {
            var input = "Alice ";
            var action = _actionFactory.Create(input) as ShowBarks;

            Assert.That(action, Is.Not.Null, "Wrong action type");
            Assert.That(action.Username, Is.EqualTo("Alice"));
        }

        [Test] public void
        create_post_action_when_input_contains_arrow_symbol()
        {
            var input = "Bob->Testing this barker thing, sending a message";
            var action = _actionFactory.Create(input) as Post;

            Assert.That(action, Is.Not.Null, "Wrong action type");
            Assert.That(action.Username, Is.EqualTo("Bob"));
            Assert.That(action.Messages[0], Is.EqualTo("Testing this barker thing, sending a message"));
        }

        [Test] public void
        create_post_action_when_input_contains_multiple_arrow_symbol()
        {
            var input = "Alice->message1->message2->message3";
            var action = _actionFactory.Create(input) as Post;

            Assert.That(action, Is.Not.Null, "Wrong action type");
            Assert.That(action.Username, Is.EqualTo("Alice"));
            Assert.That(action.Messages[0], Is.EqualTo("message1"));
            Assert.That(action.Messages[1], Is.EqualTo("message2"));
            Assert.That(action.Messages[2], Is.EqualTo("message3"));
        }

        [Test] public void
        create_post_action_when_input_contains_multiple_arrow_symbol_with_spaces()
        {
            var input = "Alice -> message1 ->message2 ->message3";
            var action = _actionFactory.Create(input) as Post;

            Assert.That(action, Is.Not.Null, "Wrong action type");
            Assert.That(action.Username, Is.EqualTo("Alice"));
            Assert.That(action.Messages[0], Is.EqualTo("message1"));
            Assert.That(action.Messages[1], Is.EqualTo("message2"));
            Assert.That(action.Messages[2], Is.EqualTo("message3"));
        }

        [Test] public void
        create_show_wall_action_when_input_contains_wall()
        {
            var input = "Bob wall";
            var action = _actionFactory.Create(input) as ShowWall;

            Assert.That(action, Is.Not.Null, "Wrong action type");
            Assert.That(action.Username, Is.EqualTo("Bob"));
        }

        [Test] public void
        create_follow_wall_action_when_input_contains_follow()
        {

            var input = "Bob follows Allice";
            var action = _actionFactory.Create(input) as Follow;

            Assert.That(action, Is.Not.Null, "Wrong action type");
            Assert.That(action.Username, Is.EqualTo("Bob"));
            Assert.That(action.FollowingUsername, Is.EqualTo("Allice"));
        }
    }
}
