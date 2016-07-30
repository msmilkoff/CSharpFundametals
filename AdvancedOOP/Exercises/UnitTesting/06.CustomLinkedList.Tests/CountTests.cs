namespace _06.CustomLinkedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CountTests
    {
        private DynamicList<int> list;

        [TestInitialize]
        public void InitializeLinkedList()
        {
            this.list = new DynamicList<int>();
        }

        [TestMethod]
        public void Count_EmptyList_ShoudReturnZero()
        {
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void Count_AddingElements_ShouldIncrementOnEveryAddition()
        {
            int expected = 0;
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
                expected++;
                Assert.AreEqual(expected, list.Count);
            }
        }
    }
}