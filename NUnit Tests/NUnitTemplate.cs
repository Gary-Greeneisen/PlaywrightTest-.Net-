using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTest_.Net_.NUnit_Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class NUnitTemplate : PageTest
    {
        [SetUp]
        public void Initialize()
        {

        }

        [Test]
        public void UnitTest1()
        {
        }

        [TearDown]
        public void Cleanup()
        { 
        }
    }
}
