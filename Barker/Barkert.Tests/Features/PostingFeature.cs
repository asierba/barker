using System;
using System.IO;
using Barker;
using NUnit.Framework;

namespace Barkert.Tests
{
    [TestFixture]
    class PostingFeature
    {
        private StringWriter _consoleOutput;

        [SetUp]
        public void MockConsoleOutput()
        {
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);
        }

        private static void MockConsoleInput(string exit)
        {
            var input = new StringReader(exit);
            Console.SetIn(input);
        }

        //[Test]
        public void
        user_can_publish_message_to_personal_timeline()
        {
            MockConsoleInput(@"Alice->I love the weather today
Bob->Damn!We lost!
Bob->Good game though.
Alice
Bob
EXIT");

            Program.Main(new string[] { });

            Assert.That(_consoleOutput.ToString(), Is.StringEnding(@"> Alice
I love the weather today(5 minutes ago)
> Bob
Good game though. (1 minute ago)
Damn!We lost!(2 minutes ago)
Good bye!"));
        }
    }
}
