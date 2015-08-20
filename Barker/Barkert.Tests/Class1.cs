using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Barkert.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void ATest()
        {
            Assert.That(true, Is.True);
        }
    }
}
