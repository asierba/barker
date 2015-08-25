using Barker;
using Barker.App.Actions;
using Barker.Delivery.CLI;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests
{
    class ControllerShould
    {
        [Test] public void
        execute_command_based_in_input()
        {
            var commandFactory = new Mock<ICommandFactory>();
            var controller = new Controller(commandFactory.Object);

            var aCommand = new Mock<ICommand>();
            commandFactory.Setup(x => x.Create("Bob")).Returns(aCommand.Object);

            controller.Run("Bob");

            aCommand.Verify(x => x.Execute());

        }
    }
}
