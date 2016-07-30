namespace _06.CustomLinkedList.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class RemoveTests
    {
        private DynamicList<int> list;

        [TestInitialize]
        public void InitializeLinkedList()
        {
            this.list = new DynamicList<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_NegativeIndex_ShouldThrow()
        {
            this.list.Add(5);
            this.list.RemoveAt(-2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_OutOfRangeIndex_ShouldThrow()
        {
            this.list.Add(5);
            this.list.RemoveAt(2);
        }

        [TestMethod]
        public void RemoveAt_ValidIndex_ShouldRemoveElement()
        {
            this.list.Add(5);
            this.list.RemoveAt(0);

            Assert.IsFalse(this.list.Contains(5));
        }

        [TestMethod]
        public void Remove_NonExistantItem_ShouldReturnNegativeOne()
        {
            list.Add(4);
            list.Add(5);

            int actual = list.Remove(100);
            int expected = -1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_ExistantItem_ShouldReturnIndexOfRemovedItem()
        {
            list.Add(4);
            list.Add(5);

            int actual = list.Remove(4);
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_ExistantItem_ShouldRemoveItem()
        {
            list.Add(4);
            list.Add(5);

            list.Remove(5);

            Assert.IsFalse(list.Contains(5));
        }
    }
}