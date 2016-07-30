namespace _04.BubbleSort.Tests
{
    using System;
    using System.Collections.Generic;
    using BubbleSort;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BubbleSortTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BubbleSort_ZeroElements_ShouldThrow()
        {
            var list = new List<int>();
            Bubble.Sort(list);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BubbleSort_NullCollection_ShouldThrow()
        {
            List<int> list = null;
            Bubble.Sort(list);
        }

        [TestMethod]
        public void BubbleSort_OneElement_ShoundNotChangeCollection()
        {
            var actualCollection = new List<int> { 42 };
            var expectedCollection = new List<int> { 42 };

            Bubble.Sort(actualCollection);

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [TestMethod]
        public void BubbleSort_CollectionAlreadySorted_ShoudNotChangeCollection()
        {
            var actual = new List<int> { 1, 2, 3, 4, 5 };
            var expected = new List<int> { 1, 2, 3, 4, 5 };

            Bubble.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BubbleSort_UnsortedCollection_ShoudBeSortedCorrectly()
        {
            var actual = new List<int> { 9, 0, -62, 49, 3, -11, 6, 79, 2 };
            var expected = new List<int> { -62, -11, 0, 2, 3, 6, 9, 49, 79 };

            Bubble.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BubbleSort_CollectionSortedInReverse_ShoudBeSortedInAscending()
        {
            var actual = new List<int> { 5, 4, 3, 2, 1 };
            var expected = new List<int> { 1, 2, 3, 4, 5 };

            Bubble.Sort(actual);
            
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BubbleSort_AllItemsAreEqual_ShouldNotChangeCollection()
        {
            var actual = new List<int> { 5, 5, 5, 5, 5 };
            var expected = new List<int> { 5, 5, 5, 5, 5 };

            Bubble.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
