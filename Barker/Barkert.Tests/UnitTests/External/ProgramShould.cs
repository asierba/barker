using Barker.Delivery.CLI;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests.External
{
    [TestFixture]
    public class ProgramShould
    {
        private Mock<IConsole> _console;
        private Mock<IController> _controller;

        [SetUp]
        public void MockConsole()
        {
            _console = new Mock<IConsole>();
            Program.Container.OverrideRegister(_console.Object);
            _controller = new Mock<IController>();
            Program.Container.OverrideRegister(_controller.Object);
        }

        [Test] public void 
        exit_when_user_inputs_special_word()
        {
            _console.Setup(x => x.ReadLine())
                .Returns("EXIT");

            Program.Main(new string[] { });

            _controller.Verify(x => x.Run(It.IsAny<string>()), Times.Never);
            _console.Verify(x => x.WriteLine("Good bye!"));
        }
    }
}
