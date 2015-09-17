using Barker.App.Actions;
using Barker.Delivery.CLI;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests.Delivery.CLI
{
    class ControllerShould
    {
        [Test] public void
        execute_action_based_in_input()
        {
            var actionFactory = new Mock<IActionFactory>();
            var controller = new Controller(actionFactory.Object);

            var anAction = new Mock<IAction>();
            actionFactory.Setup(x => x.Create("Bob")).Returns(anAction.Object);

            controller.Run("Bob");

            anAction.Verify(x => x.Execute());

        }
    }
}
