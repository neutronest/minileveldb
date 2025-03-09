
using minileveldb.interfaces;
using NUnit.Framework;

namespace minileveldb.test
{
    [TestFixture]
    public class SkipListTest
    {
        private SkipListImpl skipList;

        [SetUp]
        public void SetUp()
        {
            skipList = new SkipListImpl();
        }

        [TearDown]
        public void TeanDown()
        {
            skipList.Clear();
        }


        [Test]
        public void Test_PutAndGet_ShouldReturnCorrectValue()
        {
            // Arrange && Act
            skipList.Put("key1", "value1");

            // Assert
            Assert.AreEqual("value1", skipList.Get("key1"));
        }

        [Test]
        public void Test_ShouldReturnNullForNonExistentKey()
        {
            // Arrange && Act && Assert
            Assert.That(skipList.Get("nonexistent"), Is.Null);
        }

        [Test]
        public void Test_Put_ShouldOverrideExistingValue()
        {
            // Arrange && Act
            skipList.Put("key1", "value1");
            skipList.Put("key1", "newValue");

            // Assert
            var expectedValue = "newValue";
            Assert.That(expectedValue, Is.EqualTo(skipList.Get("key1")));
        }

        [Test]
        public void Delete_ShouldRemoveKey()
        {
            skipList.Put("key1", "value1");
            skipList.Delete("key1");
            Assert.That(skipList.Get("key1"), Is.Null);
        }

        [Test]
        public void ContainsKey_ShouldReturnTrueIfKeyExists()
        {
            skipList.Put("key1", "value1");
            Assert.That(skipList.ContainKey("key1"), Is.True);
        }

        [Test]
        public void Size_ShouldReturnCorrectCount()
        {
            skipList.Put("key1", "value1");
            skipList.Put("key2", "value2");

            var expectedValue = 2;
            Assert.That(expectedValue, Is.EqualTo(skipList.Size()));
        }

        [Test]
        public void Test_SkipList_ShouldIncreaseLevelsWithMoreData()
        {
            // Arrange && Act
            var elementCount = 1000;
            for (int i = 1; i <= elementCount; i++)
            {
                skipList.Put(i.ToString(), $"value{i}");
            }

            // Assert
            Assert.That(
                skipList.GetCurrentMaxLevel(), 
                Is.GreaterThanOrEqualTo(5), 
                "SkipList level should be at least 5 for 1000 elements");
        }

        [Test]
        public void Test_SkipList_ShouldHaveExponentiallyDecreasingNodesPerLevel()
        {
            var elementCount = 1000;
            for (int i = 1; i <= elementCount; i++)
            {
                skipList.Put(i.ToString(), $"value{i}");
            }

            var levelCounts = skipList.GetElementCountForEachLevel().ToArray();

            for (int i = 1; i < levelCounts.Length; i++)
            {
                if (levelCounts[i] > 0)
                {
                    // Assert.Less(levelCounts[i], levelCounts[i - 1], $"Level {i} should have fewer nodes than level {i - 1}");
                    Assert.That(
                        levelCounts[i],
                        Is.LessThan(levelCounts[i-1]),
                        $"Level {i} should have fewer nodes than level {i - 1}");
                }
            }
        }

        [Test]
        public void Test_SkipList_ShouldRetrievelElementsInLogNSteps()
        {
            // Arrange
            var elementCount = 1000;
            for (int i = 1; i <= elementCount; i++)
            {
                skipList.Put(i.ToString(), $"value{i}");
            }

            // Act
            var steps = skipList.CountStepsToFind("999");
            var expectedMaxQueryTimesLimit = 20;

            // Assert
            Assert.That(
                steps,
                Is.LessThan(expectedMaxQueryTimesLimit),
                "Search steps should be much lower than 1000 (log(n) behavior)"
                );
        }
    }
}
