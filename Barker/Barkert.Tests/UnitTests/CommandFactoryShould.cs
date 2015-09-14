using Barker.App.Actions;
using Barker.Delivery.CLI;
using Barker.External.Repositories;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests
{
    [TestFixture]
    class CommandFactoryShould
    {
        private CommandFactory _commandFactory;

        [SetUp]
        public void Setup()
        {
            _commandFactory = new CommandFactory(new Mock<IUserRepository>().Object,  new Mock<IPrinter>().Object, new Mock<IClock>().Object);
        }

        [Test] public void
        create_show_user_barks_command_when_input_contains_just_username()
        {
            var input = "Alice ";
            var command = _commandFactory.Create(input) as ShowBarksCommand;

            Assert.That(command, Is.Not.Null, "Wrong command type");
            Assert.That(command.Username, Is.EqualTo("Alice"));
        }

        [Test] public void
        create_post_command_when_input_contains_arrow_symbol()
        {
            var input = "Bob->Testing this barker thing, sending a message";
            var command = _commandFactory.Create(input) as PostCommand;

            Assert.That(command, Is.Not.Null, "Wrong command type");
            Assert.That(command.Username, Is.EqualTo("Bob"));
            Assert.That(command.Messages[0], Is.EqualTo("Testing this barker thing, sending a message"));
        }

        [Test] public void
        create_post_command_when_input_contains_multiple_arrow_symbol()
        {
            var input = "Alice->message1->message2->message3";
            var command = _commandFactory.Create(input) as PostCommand;

            Assert.That(command, Is.Not.Null, "Wrong command type");
            Assert.That(command.Username, Is.EqualTo("Alice"));
            Assert.That(command.Messages[0], Is.EqualTo("message1"));
            Assert.That(command.Messages[1], Is.EqualTo("message2"));
            Assert.That(command.Messages[2], Is.EqualTo("message3"));
        }

        [Test] public void
        create_post_command_when_input_contains_multiple_arrow_symbol_with_spaces()
        {
            var input = "Alice -> message1 ->message2 ->message3";
            var command = _commandFactory.Create(input) as PostCommand;

            Assert.That(command, Is.Not.Null, "Wrong command type");
            Assert.That(command.Username, Is.EqualTo("Alice"));
            Assert.That(command.Messages[0], Is.EqualTo("message1"));
            Assert.That(command.Messages[1], Is.EqualTo("message2"));
            Assert.That(command.Messages[2], Is.EqualTo("message3"));
        }

        [Test] public void
        create_show_wall_command_when_input_contains_wall()
        {
            var input = "Bob wall";
            var command = _commandFactory.Create(input) as ShowWallCommand;

            Assert.That(command, Is.Not.Null, "Wrong command type");
            Assert.That(command.Username, Is.EqualTo("Bob"));
        }

        [Test] public void
        create_follow_wall_command_when_input_contains_follow()
        {

            var input = "Bob follows Allice";
            var command = _commandFactory.Create(input) as FollowCommand;

            Assert.That(command, Is.Not.Null, "Wrong command type");
            Assert.That(command.Username, Is.EqualTo("Bob"));
            Assert.That(command.Following, Is.EqualTo("Allice"));
        }
    }
}
