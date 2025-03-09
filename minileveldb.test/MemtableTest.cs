using minileveldb.interfaces;
using Moq;
using NUnit.Framework;

namespace minileveldb.test
{
    [TestFixture]
    public class MemtableTest
    {
        private Memtable? memtable;
        private Mock<ISkipList>? mockSkipList;

        [SetUp]
        public void Setup()
        {
            mockSkipList = new Mock<ISkipList>();
            memtable = new Memtable(mockSkipList.Object);
        }

        [Test]
        public void Put_ShouldCallSkipListPut()
        {
            ArgumentNullException.ThrowIfNull(memtable);
            ArgumentNullException.ThrowIfNull(mockSkipList);

            memtable.Put("key1", "value1");
            mockSkipList.Verify(s => s.Put("key1", "value1"), Times.Once);
        }

        [Test]
        public void Get_ShouldReturnValueFromSkipList()
        {
            ArgumentNullException.ThrowIfNull(memtable);
            ArgumentNullException.ThrowIfNull(mockSkipList);

            mockSkipList.Setup(s => s.Get("key1")).Returns("value1");
            Assert.AreEqual("value1", memtable.Get("key1"));
        }

    }
}
