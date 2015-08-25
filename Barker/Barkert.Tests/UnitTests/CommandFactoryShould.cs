using Barker;
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
            _commandFactory = new CommandFactory(new Mock<IBarkRepository>().Object, new Mock<IPrinter>().Object);
        }

        [Test] public void
        create_show_user_barks_command_when_input_contains_just_username()
        {
            var input = "Alice";
            ICommand command = _commandFactory.Create(input);
            Assert.That(command, Is.TypeOf(typeof(ShowBarksCommand)));
        }

        [Test] public void
        create_post_command_when_input_contains_arrow_symbol()
        {
            var input = "Bob->Testing this barker thing, sending a message";
            ICommand command = _commandFactory.Create(input);
            Assert.That(command, Is.TypeOf(typeof(PostCommand)));
        }
    }
}
