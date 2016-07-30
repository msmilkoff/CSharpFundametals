namespace _06.CustomLinkedList.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IndexerTests
    {
        private DynamicList<int> list;

        [TestInitialize]
        public void InitializeLinkedList()
        {
            this.list = new DynamicList<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_NegativeIndex_ShouldThrow()
        {
            list.Add(1);
            list.Add(2);

            int number = list[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_OutOfRangeIndex_ShouldThrow()
        {
            list.Add(4);
            list.Add(5);

            int number = list[3];
        }

        [TestMethod]
        public void Indexer_ValidIndex_ShouldReturnCorrectElement()
        {
            list.Add(10);
            list.Add(20);

            int actual = list[1];
            int expected = 20;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_SetAtValidIndex_ShouldSetElementCorrectly()
        {
            list.Add(10);
            list.Add(20);

            list[1] = 42;

            Assert.AreEqual(list[1], 42);
        }
    }
}