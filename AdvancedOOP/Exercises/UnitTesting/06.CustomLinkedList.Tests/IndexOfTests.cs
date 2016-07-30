namespace _06.CustomLinkedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IndexOfTests
    {
        private DynamicList<int> list;

        [TestInitialize]
        public void InitializeLinkedList()
        {
            this.list = new DynamicList<int>();
        }

        [TestMethod]
        public void IndexOf_NonExistantItem_ShouldReturnNegativeOne()
        {
            list.Add(42);

            int actual = list.IndexOf(100);
            int expected = -1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_ExistantItem_ShouldReturnCorrectIndex()
        {
            list.Add(42);

            int actual = list.IndexOf(42);
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}