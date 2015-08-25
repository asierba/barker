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
        [Test] public void 
        exit_when_user_inputs_special_word()
        {
            var console = new Mock<IConsole>();
            Program.Console = console.Object;

            console.Setup(x => x.ReadLine())
                .Returns("EXIT");
                        
            Program.Main(new string[] { });

            console.Verify(x => x.WriteLine("Good bye!"));
        }
    }
}
