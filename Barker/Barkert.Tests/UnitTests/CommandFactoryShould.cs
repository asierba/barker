using Barker;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests
{
    [TestFixture]
    class CommandFactoryShould
    {
        [Test] public void
        create_show_user_messages_command_when_input_contains_just_username()
        {
            var input = "Alice";
            var commandFactory = new CommandFactory();
            ICommand command = commandFactory.Create(input);
            Assert.That(command, Is.TypeOf(typeof(ShowUserMessagesCommand)));
        }
    }
}
