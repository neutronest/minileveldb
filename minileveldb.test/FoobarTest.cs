using NUnit.Framework;

namespace minileveldb.test
{
    [TestFixture]
    public class FoobarTest
    {
        [Test]
        public void TestFoobar()
        {
            var expectValue = true;
            Assert.That(expectValue, Is.True);
        }
    }
}
