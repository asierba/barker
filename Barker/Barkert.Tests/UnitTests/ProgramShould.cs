using System;
using System.IO;
using Barker;
using Barker.Delivery.CLI;
using Moq;
using NUnit.Framework;

namespace Barkert.Tests.UnitTests
{
    [TestFixture]
    public class ProgramShould
    {
        private StringWriter _consoleOutput;

        [SetUp]
        public void SetUp()
        {
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);

            var controller = new Mock<IController>();
            Program.Controller = controller.Object;
        }

        [Test] public void 
        exit_when_user_inputs_special_word()
        {
            MockConsoleInput("EXIT");
                        
            Program.Main(new string[] { });

            Assert.That(_consoleOutput.ToString(), Is.StringEnding("Good bye!"));
        }

        private static void MockConsoleInput(string exit)
        {
            var input = new StringReader(exit);
            Console.SetIn(input);
        }
    }
}
