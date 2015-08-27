using Barker.Delivery.CLI;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests
{
    [TestFixture]
    public class ProgramShould
    {
        private Mock<IConsole> _console;

        [SetUp]
        public void MockConsole()
        {
            _console = new Mock<IConsole>();
            Program.Container.OverrideRegister(_console.Object);
        }

        [Test] public void 
        exit_when_user_inputs_special_word()
        {
            _console.Setup(x => x.ReadLine())
                .Returns("EXIT");

            Program.Main(new string[] { });

            _console.Verify(x => x.WriteLine("Good bye!"));
        }
    }
}
