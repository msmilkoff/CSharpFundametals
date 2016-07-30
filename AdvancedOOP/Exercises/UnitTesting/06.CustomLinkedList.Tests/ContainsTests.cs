namespace _06.CustomLinkedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ContainsTests
    {
        private DynamicList<int> list;

        [TestInitialize]
        public void InitializeLinkedList()
        {
            this.list = new DynamicList<int>();
        }

        [TestMethod]
        public void Contains_ExistingItem_ShouldReturnTrue()
        {
            int item = 5;
            list.Add(item);

            bool actual = list.Contains(item);
            bool expected = true;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Contains_NonExistantItem_ShouldReturnFalse()
        {
            list.Add(100);

            int testItem = 500;

            bool actual = list.Contains(testItem);
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }
    }
}